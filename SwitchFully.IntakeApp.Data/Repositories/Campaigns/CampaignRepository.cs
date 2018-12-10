using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwitchFully.IntakeApp.Domain.Campaigns;

namespace SwitchFully.IntakeApp.Data.Repositories.Campaigns
{
    public class CampaignRepository : IRepository<Campaign>
    {
        private readonly SwitchFullyIntakeAppContext _context;

        public CampaignRepository(SwitchFullyIntakeAppContext context)
        {
            _context = context;
        }

        public Campaign Create(Campaign objectToCreate)
        {
            throw new NotImplementedException();
        }

        public List<Campaign> GetAll()
        {
            return _context.Campaigns.ToList();
        }

        public Campaign GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Campaign Update(Campaign objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
