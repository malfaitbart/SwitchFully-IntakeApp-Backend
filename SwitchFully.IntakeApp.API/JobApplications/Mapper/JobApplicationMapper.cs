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
		private readonly ICampaignMapper _campaignMapper;
		private readonly ICandidateMapper _candidateMapper;

		public JobApplicationMapper(ICampaignMapper campaignMapper, ICandidateMapper candidateMapper)
		{
			_campaignMapper = campaignMapper;
			_candidateMapper = candidateMapper;
		}

		public JobApplicationDto DomainToDto(JobApplication jobApplication)
		{
			return new JobApplicationDto
			{
				Id = jobApplication.Id.ToString(),
				CandidateId = jobApplication.CandidateId.ToString(),
				Candidate = _candidateMapper.DomainToDto(jobApplication.Candidate),
				CampaignId = jobApplication.CampaignId.ToString(),
				Campaign = _campaignMapper.CampaignToCampaignDTOReturn(jobApplication.Campaign),
				StatusId = jobApplication.StatusId,
				Status = jobApplication.Status,
				CvId = jobApplication.CvId,
				CV = jobApplication.CV,
				MotivationId = jobApplication.MotivationId,
				Motivation = jobApplication.Motivation
			};
		}

		public JobApplication DtoToDomain(JobApplicationDto jobApplicationDto)
		{
			return new JobApplication(
				Guid.Parse(jobApplicationDto.Id), 
				Guid.Parse(jobApplicationDto.CandidateId), 
				_candidateMapper.DtoToDomain(jobApplicationDto.Candidate),
				Guid.Parse(jobApplicationDto.CampaignId), 
				_campaignMapper.CampaignDTOReturnToCampaign(jobApplicationDto.Campaign),
				jobApplicationDto.StatusId,
				jobApplicationDto.Status,
				jobApplicationDto.CvId,
				jobApplicationDto.CV,
				jobApplicationDto.MotivationId,
				jobApplicationDto.Motivation
				);
		}

		internal JobApplication Dto_CreateToDomain(JobApplicationDto_Create objectToCreate)
		{
			return new JobApplication(objectToCreate.CandidateId, objectToCreate.CampaignId);
		}
	}
}