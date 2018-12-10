using System;
using System.Collections.Generic;
using System.Text;
using SwitchFully.IntakeApp.Data.Repositories;
using SwitchFully.IntakeApp.Data.Repositories.Campaigns;
using SwitchFully.IntakeApp.Domain.Campaigns;

namespace SwitchFully.IntakeApp.Service.Campaigns
{
    public class CampaignService : ICampaignService
    {
        private readonly CampaignRepository _campaignRepo;

        public CampaignService(CampaignRepository campaignRepo)
        {
            _campaignRepo = campaignRepo;
        }

        public List<Campaign> GetAllCampaigns()
        {
            return _campaignRepo.GetAll();
        }
    }
}
