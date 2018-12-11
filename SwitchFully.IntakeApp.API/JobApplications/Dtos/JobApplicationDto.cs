using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.API.Candidates.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.JobApplications.Dtos
{
	public class JobApplicationDto
	{
		public string Id { get; set; }
		public Guid CandidateId { get; set; }
		public Guid CampagneId { get; set; }
		public int StatusId { get; set; }

	}
}
