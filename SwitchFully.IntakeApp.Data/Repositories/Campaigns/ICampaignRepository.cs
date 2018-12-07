using System;
using System.Collections.Generic;
using System.Text;
using SwitchFully.IntakeApp.Domain.Campaigns;

namespace SwitchFully.IntakeApp.Data.Repositories.Campaigns
{
    public interface ICampaignRepository
    {
        List<Campaign> GetAllCampaigns();
    }
}
