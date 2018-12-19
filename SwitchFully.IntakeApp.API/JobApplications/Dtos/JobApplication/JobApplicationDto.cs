using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.API.Candidates.DTO;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Domain.FileManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.JobApplications.Dtos
{
	public class JobApplicationDto
	{
		public string Id { get; set; }
		public CandidateDto Candidate { get; set; }
		public CampaignDTO_Return Campaign { get; set; }
		public Status Status { get; set; }
		public File CV { get; set; }
		public File Motivation { get; set; }
	}
}