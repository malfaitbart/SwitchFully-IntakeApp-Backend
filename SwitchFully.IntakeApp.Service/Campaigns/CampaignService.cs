using SwitchFully.IntakeApp.Data.Repositories.Campaigns;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.Campaigns
{
	public class CampaignService : ICampaignService
	{
		private readonly CampaignRepository _campaignRepo;

		public CampaignService(CampaignRepository campaignRepo)
		{
			_campaignRepo = campaignRepo;
		}

        public async Task<Campaign> CreateNewCampaign(Campaign campaign)
        {
            if (campaign == null)
            {
                throw new ExceptionsHandler("campaign", "fields are not filled in correctly");
            }

			return await _campaignRepo.Create(campaign);
		}

		public async Task<List<Campaign>> GetAllCampaigns()
		{
			return await _campaignRepo.GetAll();
		}

		public async Task<Campaign> GetSingleCampaignByID(string id)
		{

			return await _campaignRepo.GetById(new Guid(id));
		}
	}
}
