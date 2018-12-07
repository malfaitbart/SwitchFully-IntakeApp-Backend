using System;
using System.Collections.Generic;
using System.Text;
using SwitchFully.IntakeApp.Domain.Campaigns;

namespace SwitchFully.IntakeApp.Service.Campaigns
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepo _campaignRepo;

        public CampaignService(ICampaignRepo campaignRepo)
        {
            _campaignRepo = campaignRepo;
        }

        public List<Campaign> GetAllCampaigns()
        {
            
        }
    }
}
