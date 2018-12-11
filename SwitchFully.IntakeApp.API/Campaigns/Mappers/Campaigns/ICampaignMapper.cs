using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.Domain.Campaigns;
using System.Collections.Generic;

namespace SwitchFully.IntakeApp.API.Campaigns.Mappers
{
	public interface ICampaignMapper
	{
		List<CampaignDTO_Return> CampaignListToCampaignDTOReturnList(List<Campaign> campaignList);
		Campaign CampaignDTOCreateToCampaign(CampaignDTO_Create campaignDTO);
		CampaignDTO_Return CampaignToCampaignDTOReturn(Campaign campaign);
		List<Campaign> CampaignDTOCreateListToCampaignList(List<CampaignDTO_Create> campaignDTOList);
	}
}
