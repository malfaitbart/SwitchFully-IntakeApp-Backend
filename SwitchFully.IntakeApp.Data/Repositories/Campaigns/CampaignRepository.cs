using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories.Campaigns
{
    public class CampaignRepository : IRepository<Campaign>
    {
        private readonly SwitchFullyIntakeAppContext _context;

        public CampaignRepository(SwitchFullyIntakeAppContext context)
        {
            _context = context;
        }

        public async Task<Campaign> Create(Campaign campaign)
        {
            var campaignToCreate = await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
            return campaign;
        }

        public async Task<List<Campaign>> GetAll()
        {
            return await _context.Campaigns.ToListAsync();
        }

        public Task<Campaign> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Campaign> UpdateAsync(Campaign objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
