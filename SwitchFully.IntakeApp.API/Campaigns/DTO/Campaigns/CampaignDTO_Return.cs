using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.Campaigns.DTO
{
    public class CampaignDTO_Return
    {
        public Guid CampaignId { get;  set; }
        public string Name { get;  set; }
        public string Client { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public bool Status { get;  set; }
    }
}
