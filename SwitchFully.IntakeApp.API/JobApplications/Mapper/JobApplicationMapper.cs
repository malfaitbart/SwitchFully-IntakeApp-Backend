using SwitchFully.IntakeApp.API.Campaigns.Mappers;
using SwitchFully.IntakeApp.API.Candidates.Mapper;
using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using SwitchFully.IntakeApp.API.JobApplications.Dtos.JobApplication;
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
				Candidate = _candidateMapper.DomainToDto(jobApplication.Candidate),
				Campaign = _campaignMapper.CampaignToCampaignDTOReturn(jobApplication.Campaign),
				Status = jobApplication.Status,
				CV = jobApplication.CV,
				Motivation = jobApplication.Motivation
			};
		}
		public JobApplicationDto_Overview DomainToDto_Overview(JobApplication jobApplication, string selectionStep)
		{
			var candidate = _candidateMapper.DomainToDto(jobApplication.Candidate);
			var campaign = _campaignMapper.CampaignToCampaignDTOReturn(jobApplication.Campaign);
			var status = jobApplication.Status;

			return new JobApplicationDto_Overview
			{
				Id = jobApplication.Id.ToString(),
				Candidate = candidate.FirstName + " " + candidate.LastName,
				Campaign = campaign.Name,
				Status = status.Description,
				SelectionStep = selectionStep
			};
		}

		public JobApplication DtoToDomain(JobApplicationDto jobApplicationDto)
		{
			return new JobApplication(
				Guid.Parse(jobApplicationDto.Id), 
				_candidateMapper.DtoToDomain(jobApplicationDto.Candidate),
				_campaignMapper.CampaignDTOReturnToCampaign(jobApplicationDto.Campaign),
				jobApplicationDto.Status,
				jobApplicationDto.CV,
				jobApplicationDto.Motivation
				);
		}

		internal JobApplication Dto_CreateToDomain(JobApplicationDto_Create objectToCreate)
		{
			return new JobApplication(objectToCreate.CandidateId, objectToCreate.CampaignId, objectToCreate.CvId, objectToCreate.MotivationId);
		}
	}
}