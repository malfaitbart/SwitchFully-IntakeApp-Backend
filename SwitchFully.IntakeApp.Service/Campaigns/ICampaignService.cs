using SwitchFully.IntakeApp.Domain.Campaigns;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Service.Campaigns
{
    public interface ICampaignService
    {
        List<Campaign> GetAllCampaigns();
        
    }
}
