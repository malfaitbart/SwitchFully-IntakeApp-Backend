using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Domain.FileManagement;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using System;
using System.Collections.Generic;

namespace SwitchFully.IntakeApp.Domain.JobApplications
{
	public class JobApplication
	{
		public Guid Id { get; private set; }
		public Guid CandidateId { get; private set; }
		public Candidate Candidate { get; private set; }
		public Guid CampaignId { get; private set; }
		public Campaign Campaign { get; private set; }
		public int StatusId { get; private set; }
		public Status Status { get; private set; }
		public Guid CvId { get; private set; }
		public File CV { get; private set; }
		public Guid MotivationId { get; private set; }
		public File Motivation { get; private set; }

		public List<Screening> Screening { get; private set; } = new List<Screening>();



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

		public JobApplication(Guid id, Candidate candidate, Campaign campaign, Status status, File cV, File motivation)
		{
			Id = id;
			Candidate = candidate;
			Campaign = campaign;
			Status = status;
			CV = cV;
			Motivation = motivation;
		}

		public JobApplication(Guid candidateId, Guid campaignId, Guid cvId, Guid motivationId)
		{
			Id = Guid.NewGuid();
			CandidateId = candidateId;
			CampaignId = campaignId;
			CvId = cvId;
			MotivationId = motivationId;
			StatusId = 2;
		}

		public JobApplication(Guid id, Guid candidateId, Guid campagneId, int statusId)
		{
			Id = id;
			CandidateId = candidateId;
			CampaignId = campagneId;
			StatusId = statusId;
		}

		public JobApplication(Guid id, Guid candidateId, Candidate candidate, Guid campaignId, Campaign campaign, int statusId, Status status, Guid cvid, File cv, Guid motivationid, File motivation)
		{
			Id = id;
			CandidateId = candidateId;
			Candidate = candidate;
			CampaignId = campaignId;
			Campaign = campaign;
			StatusId = statusId;
			Status = status;
			CvId = cvid;
			CV = cv;
			MotivationId = motivationid;
			Motivation = motivation;
		}

		public void ChangeStatusToGivenStatusID(int givenStatusId)
		{
			StatusId = givenStatusId;
		}
	}
}
