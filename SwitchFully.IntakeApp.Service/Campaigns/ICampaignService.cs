
using SwitchFully.IntakeApp.Domain.Campaigns;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.Campaigns
{
	public interface ICampaignService
	{
		Task<List<Campaign>> GetAllCampaigns();
		Task<Campaign> CreateNewCampaign(Campaign campaign);
		Task<Campaign> GetSingleCampaignByID(string id);
	}
}
