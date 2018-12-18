using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.Candidates;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.JobApplications
{
	public class JobApplication
	{
		public Guid Id { get; private set; }
		public Guid CandidateId { get; private set; }
		public Candidate Candidate { get; private set; }
		public Guid CampaignId { get; private set; }
		public Campaign Campaign { get; private set; }
		public int StatusId { get; private  set; }
		public Status Status { get; private set; }

        private JobApplication()
		{
		}

		public JobApplication(Guid candidateId, Guid campaignId)
		{
			Id = Guid.NewGuid();
			CandidateId = candidateId;
			CampaignId = campaignId;
			StatusId = 2;
		}

		public JobApplication(Guid id, Guid candidateId, Guid campagneId, int statusId)
		{
			Id = id;
			CandidateId = candidateId;
			CampaignId = campagneId;
			StatusId = statusId;
		}

		public JobApplication(Guid id, Guid candidateId, Candidate candidate, Guid campaignId, Campaign campaign, int statusId, Status status)
		{
			Id = id;
			CandidateId = candidateId;
			Candidate = candidate;
			CampaignId = campaignId;
			Campaign = campaign;
			StatusId = statusId;
			Status = status;
		}

        public virtual void ChangeStatusToGivenStatusID( int givenStatusId)
        {
            StatusId = givenStatusId;
        }
	}
}
