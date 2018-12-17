using SwitchFully.IntakeApp.Data.Repositories.FileUploads;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications;
using SwitchFully.IntakeApp.Domain.FileManagement;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.JobApplications
{
	public class JobApplicationService : IJobApplicationService
	{
		private readonly JobApplicationRepository _repository;
		private readonly FileRepository _fileRepository;
		private readonly ILoggerManager _loggerManager;

		public JobApplicationService(JobApplicationRepository repository, FileRepository fileRepository, ILoggerManager loggerManager)
		{
			_repository = repository;
			_fileRepository = fileRepository;
			_loggerManager = loggerManager;
		}

		public async Task<JobApplication> Create(JobApplication jobApplication)
		{
			return await _repository.Create(jobApplication);
		}

		public async Task<List<JobApplication>> GetAll()
		{
			return await _repository.GetAll();
		}

		public async Task<JobApplication> GetById(string id)
		{
			var g = Guid.Parse(id);
			return await _repository.GetById(g);
		}

		public async Task RejectJobApplication(JobApplication jobApplicationByID)
		{
			jobApplicationByID.ChangeStatusToGivenStatusID(3);
			await _repository.Update(jobApplicationByID);
		}

		public async Task<bool> Delete(JobApplication jobApplication)
		{
			throw new NotImplementedException();
		}

		public async Task<JobApplication> Update(JobApplication jobApplication)
		{
			return await _repository.Update(jobApplication);
		}

		public async Task<File> uploadFile(File formFile)
		{
			return await _fileRepository.Create(formFile);
		}
	}
}
