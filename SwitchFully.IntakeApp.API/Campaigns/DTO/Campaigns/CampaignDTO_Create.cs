using SwitchFully.IntakeApp.Domain.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.Campaigns.DTO
{
    public class CampaignDTO_Create
    {
        public string Name { get;  set; }
        public string Client { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
    }
}
