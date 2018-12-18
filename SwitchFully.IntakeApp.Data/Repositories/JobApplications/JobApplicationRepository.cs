using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.JobApplications;
using System;
using System.Collections.Generic;
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

		public async Task<JobApplication> Create(JobApplication applicationToCreate)
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
				.Include(jp => jp.Campaign)
				.Include(jp => jp.Candidate)
				.Include(jp => jp.Status)
				.FirstOrDefaultAsync(jp => jp.Id == id);
		}

		public async Task<JobApplication> Update(JobApplication objectToUpdate)
		{
			var jobApplication = await _context.JobApplications.FindAsync(objectToUpdate.Id);
			if (jobApplication == null)
			{
				throw new Exception("id not found, update not possible");
			}
			_context.Update(objectToUpdate);
			await _context.SaveChangesAsync();
			return objectToUpdate;
		}
	}
}
