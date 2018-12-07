using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.Domain.Campaigns;

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
