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

		public async Task<JobApplication> Create(JobApplication objectToCreate)
		{
			await _context.AddAsync(objectToCreate);
			return await GetById(objectToCreate.Id);
		}

		public async Task<List<JobApplication>> GetAll()
		{
			return await _context.JobApplications.ToListAsync();
		}

		public async Task<JobApplication> GetById(Guid id)
		{
			return await _context.JobApplications.FirstOrDefaultAsync(jp => jp.Id == id);
		}

		public async Task<JobApplication> Update(JobApplication objectToUpdate)
		{
			var jobApplication = GetById(objectToUpdate.Id);
			if (jobApplication == null)
			{
				throw new Exception("id not found, update not possible");
			}
			_context.Update(objectToUpdate);
			_context.SaveChanges();
			return objectToUpdate;
		}
	}
}
