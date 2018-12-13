using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SwitchFully.IntakeApp.Data.Repositories;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Service.Logging;

namespace SwitchFully.IntakeApp.Service.JobApplications
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly JobApplicationRepository _repository;
        private readonly ILoggerManager _loggerManager;

        public JobApplicationService(JobApplicationRepository repository, ILoggerManager loggerManager)
        {
            _repository = repository;
            _loggerManager = loggerManager;
        }

        public async Task<JobApplication> Create(JobApplication jobApplication)
        {
            return await _repository.Create(jobApplication);
        }

        public bool Delete(JobApplication jobApplication)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobApplication>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<JobApplication> GetById(string id)
        {
            return await _repository.GetById(Guid.Parse(id));
        }

        public async Task<JobApplication> Update(JobApplication jobApplication)
        {
            return await _repository.Update(jobApplication);
        }

    }
}
