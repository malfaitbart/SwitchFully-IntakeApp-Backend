using Microsoft.AspNetCore.Http;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Domain.FileManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.JobApplications
{
	public interface IJobApplicationService
	{
		Task<List<JobApplication>> GetAll();

		Task<JobApplication> GetById(string id);

		Task<JobApplication> Update(JobApplication jobApplication);

        Task<bool> Delete(JobApplication jobApplication);

		Task<JobApplication> Create(JobApplication jobApplication);

        Task RejectJobApplication(JobApplication jobApplicationByID);
		Task<string> StoreDocInDb(IFormFile cV, FileType type);
	}
}