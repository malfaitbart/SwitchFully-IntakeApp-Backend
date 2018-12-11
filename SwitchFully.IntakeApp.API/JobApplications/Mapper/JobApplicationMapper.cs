using SwitchFully.IntakeApp.API.Campaigns.Mappers;
using SwitchFully.IntakeApp.API.Candidates.Mapper;
using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Service.Campaigns;
using SwitchFully.IntakeApp.Service.Candidates;
using SwitchFully.IntakeApp.Service.StatusService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.JobApplications.Mapper
{
	public class JobApplicationMapper
	{

		public JobApplicationDto DomainToDto(JobApplication jobApplication)
		{
			return new JobApplicationDto
			{
				Id = jobApplication.Id.ToString(),
				CandidateId = jobApplication.CandidateId,
				CampagneId = jobApplication.CampagneId,
				StatusId = jobApplication.StatusId,
			};
		}

		public JobApplication DtoToDomain(JobApplicationDto jobApplicationDto)
		{
			return new JobApplication(
				Guid.Parse(jobApplicationDto.Id), 
				jobApplicationDto.CandidateId, 
				jobApplicationDto.CampagneId, 
				jobApplicationDto.StatusId
				);
		}
	}
}