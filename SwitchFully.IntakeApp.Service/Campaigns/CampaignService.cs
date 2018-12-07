using System;
using System.Collections.Generic;
using System.Text;
using SwitchFully.IntakeApp.Data.Repositories.Campaigns;
using SwitchFully.IntakeApp.Domain.Campaigns;

namespace SwitchFully.IntakeApp.Service.Campaigns
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepo;

        public CampaignService(ICampaignRepository campaignRepo)
        {
            _campaignRepo = campaignRepo;
        }

        public List<Campaign> GetAllCampaigns()
        {
            return _campaignRepo.GetAllCampaigns();
        }
    }
}
