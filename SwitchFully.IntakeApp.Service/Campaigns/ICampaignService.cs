
using SwitchFully.IntakeApp.Domain.Campaigns;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.Campaigns
{
    public interface ICampaignService
    {
        Task <List<Campaign>> GetAllCampaigns();
        
    }
}
