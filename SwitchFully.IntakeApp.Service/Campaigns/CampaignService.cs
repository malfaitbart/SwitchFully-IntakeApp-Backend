using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task <List<Campaign>> GetAllCampaigns()
        {
            return await _campaignRepo.GetAll();
        }

    }
}
