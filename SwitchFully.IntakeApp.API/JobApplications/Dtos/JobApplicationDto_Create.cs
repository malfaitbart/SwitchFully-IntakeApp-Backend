using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.JobApplications.Dtos
{
	public class JobApplicationDto_Create
	{
		public Guid CandidateId { get; set; }
		public Guid CampaignId { get; set; }
		public IFormFile CV { get; set; }
		public IFormFile Motivation { get; set; }

	}
}
