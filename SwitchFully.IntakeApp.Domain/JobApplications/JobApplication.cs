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
		public Guid CampagneId { get; private set; }
		public Campaign Campaign { get; private set; }
		public int StatusId { get; private set; }
		public Status Status { get; private set; }

		private JobApplication()
		{
		}

		public JobApplication(Guid candidateId, Guid campagneId, int statusId)
		{
			Id = Guid.NewGuid();
			CandidateId = candidateId;
			CampagneId = campagneId;
			StatusId = statusId;
		}

		public JobApplication(Guid id, Guid candidateId, Guid campagneId, int statusId)
		{
			Id = id;
			CandidateId = candidateId;
			CampagneId = campagneId;
			StatusId = statusId;
		}
	}
}
