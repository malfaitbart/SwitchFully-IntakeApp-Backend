using SwitchFully.IntakeApp.Data.Repositories.Campaigns;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Domain.ErrorHandling;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.Campaigns
{
	public class CampaignService : ICampaignService
	{
		private readonly CampaignRepository _campaignRepo;
        private readonly ILoggerManager _loggerManager;

        public CampaignService(CampaignRepository campaignRepo, ILoggerManager loggerManager)
        {
            _campaignRepo = campaignRepo;
            _loggerManager = loggerManager;
        }

        public async Task<Campaign> CreateNewCampaign(Campaign campaign)
        {
            _loggerManager.LogInfo($"Creating new campaign with id {campaign.CampaignId.ToString()}");
            if (campaign == null)
            {
                _loggerManager.LogError("unable to create campaign");
                throw new ExceptionsHandler("campaign", "fields are not filled in correctly");
            }

			return await _campaignRepo.Create(campaign);
		}

		public async Task<List<Campaign>> GetAllCampaigns()
		{
            _loggerManager.LogInfo("getting list of campaigns from repository");
            return await _campaignRepo.GetAll();
		}

		public async Task<Campaign> GetSingleCampaignByID(string id)
		{
            _loggerManager.LogInfo($"Getting single campaign with id {id} from repository");
            return await _campaignRepo.GetById(new Guid(id));
		}
	}
}
