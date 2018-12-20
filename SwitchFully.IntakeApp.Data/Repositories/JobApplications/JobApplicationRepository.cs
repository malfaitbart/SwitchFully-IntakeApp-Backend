using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories.JobApplications
{
    public class JobApplicationRepository
    {
        private readonly SwitchFullyIntakeAppContext _context;

        public JobApplicationRepository()
        {
        }

        public JobApplicationRepository(SwitchFullyIntakeAppContext context)
        {
            _context = context;
        }

        public async virtual Task<JobApplication> Create(JobApplication applicationToCreate)
        {
            await _context.AddAsync(applicationToCreate);
            await _context.SaveChangesAsync();
            return await GetById(applicationToCreate.Id);
        }

        public async virtual Task<List<JobApplication>> GetAll()
        {
            return await _context.JobApplications
                .Include(jp => jp.Campaign)
                .Include(jp => jp.Candidate)
                .Include(jp => jp.Status)
                .ToListAsync();

        }

        public async virtual Task<JobApplication> GetById(Guid id)
        {
            return await _context.JobApplications
                .Where(jp => jp.Id == id)
                .Include(jp => jp.Campaign)
                .Include(jp => jp.Candidate)
                .Include(jp => jp.Status)
                .Include(jp => jp.CV)
                .Include(jp => jp.Motivation)
                .Select(jp => new JobApplication
                (
                    jp.Id,
                    jp.CandidateId,
                    new Candidate
                    (
                        jp.Candidate.Id,
                        jp.Candidate.FirstName,
                        jp.Candidate.LastName,
                        jp.Candidate.Email,
                        jp.Candidate.Phone,
                        jp.Candidate.LinkedIn,
                        jp.Candidate.Comment
                    ),
                    jp.CampaignId,
                    new Campaign
                    (
                        jp.Campaign.CampaignId,
                        jp.Campaign.Name
                    ),
                    jp.StatusId,
                    new Status
                    (
                        jp.Status.Description
                    ),
                    jp.CvId,
                    new Domain.FileManagement.File
                    (
                        jp.CV.Id,
                        jp.CV.FileName
                    ),
                    jp.MotivationId,
                    new Domain.FileManagement.File
                    (
                        jp.Motivation.Id,
                        jp.Motivation.FileName
                    )
                ))
                .FirstOrDefaultAsync();
        }

        public async virtual Task<JobApplication> Update(JobApplication jobAppToUpdate)
        {
            _context.Update(jobAppToUpdate);
            await _context.SaveChangesAsync();
            return jobAppToUpdate;
        }
    }
}
