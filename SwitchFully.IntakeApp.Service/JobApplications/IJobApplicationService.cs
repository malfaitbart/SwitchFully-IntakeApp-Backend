using SwitchFully.IntakeApp.Domain.JobApplications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.JobApplications
{
	public interface IJobApplicationService
	{
		Task<List<JobApplication>> GetAll();

		Task<JobApplication> GetById(string id);

		Task<JobApplication> Update(JobApplication jobApplication);

		bool Delete(JobApplication jobApplication);

		Task<JobApplication> Create(JobApplication jobApplication);

	}
}