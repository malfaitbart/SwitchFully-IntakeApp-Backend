using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.API.Campaigns.Mappers.Clients;
using SwitchFully.IntakeApp.Domain.Campaigns;

namespace SwitchFully.IntakeApp.API.Campaigns.Mappers
{
    public class CampaignMapper : ICampaignMapper
    {

    
        public List<CampaignDTO_Return> CampaignListToCampaignDTOReturnList(List<Campaign> campaignList)
        {
            var CampaignDTO_ReturnList = new List<CampaignDTO_Return>();

            foreach (Campaign campaign in campaignList)
            {
                CampaignDTO_ReturnList.Add(CampaignToCampaignDTOReturn(campaign));
            }

            return CampaignDTO_ReturnList;
        }

        public List<Campaign> CampaignDTOCreateListToCampaignList(List<CampaignDTO_Create> campaignDTOList)
        {
            var campaignList = new List<Campaign>();
            foreach (var campaign in campaignDTOList)
            {
                campaignList.Add(CampaignDTOCreateToCampaign(campaign));
            }
            return campaignList;
        }

        public CampaignDTO_Return CampaignToCampaignDTOReturn(Campaign campaign)
        {
            return new CampaignDTO_Return()
            {
                CampaignId = campaign.CampaignId,
                Name = campaign.Name,
                EndDate = campaign.EndDate,
                StartDate = campaign.StartDate,
                Status = campaign.Status,
                Client = campaign.Client
                
            };
        }

        public Campaign CampaignDTOCreateToCampaign (CampaignDTO_Create campaignDTO)
        {
            var campaign = Campaign.CreateNewCampaign(
                campaignDTO.Name,
                campaignDTO.Client,
                campaignDTO.StartDate,
                campaignDTO.EndDate);
                return campaign;
        }

 
    }
}
