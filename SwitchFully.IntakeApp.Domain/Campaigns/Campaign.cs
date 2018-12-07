using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.Campaigns
{
    public class Campaign
    {
        public Guid CampaignId { get; private set; }
        public string Name { get; private set; }
        public List<Client> Clients { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool Status { get; private set; }


        private Campaign() { }

        private Campaign(string name, List<Client> clients, DateTime startDate, DateTime endDate)
        {
            CampaignId = Guid.NewGuid();
            Name = name;
            Clients = clients;
            StartDate = startDate;
            EndDate = endDate;
            Status = SetStatusOfCampaign();
        }

        public static Campaign CreateNewCampaign(string name, List<Client> clients, DateTime startDate, DateTime endDate )
        {
            if (string.IsNullOrWhiteSpace(name) || clients == null ||  startDate == null || endDate == null)
            {
                return null;
            }
            return new Campaign(name, clients, startDate, endDate);
        }

        private bool SetStatusOfCampaign()
        {
            DateTime dateToday = DateTime.Now;

            return dateToday < StartDate || dateToday > EndDate ? false : true;
        }

    }
}
