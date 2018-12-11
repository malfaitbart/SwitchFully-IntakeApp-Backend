using System;

namespace SwitchFully.IntakeApp.API.Campaigns.DTO
{
	public class CampaignDTO_Create
	{
		public string Name { get; set; }
		public string Client { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
