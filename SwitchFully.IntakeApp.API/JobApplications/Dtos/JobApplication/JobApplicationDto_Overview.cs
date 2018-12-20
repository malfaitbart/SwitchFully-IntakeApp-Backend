using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.API.Candidates.DTO;
using SwitchFully.IntakeApp.Domain.JobApplications;

namespace SwitchFully.IntakeApp.API.JobApplications.Dtos.JobApplication
{
	public class JobApplicationDto_Overview
	{
		public string Id { get; set; }
		public string Candidate { get; set; }
		public string Campaign { get; set; }
		public string Status { get; set; }
		public string SelectionStep { get; set; }
	}
}
