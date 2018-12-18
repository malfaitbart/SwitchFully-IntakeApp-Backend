using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories.JobApplications.Screenings
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly SwitchFullyIntakeAppContext _context;

        private ScreeningRepository()
        { }

        public ScreeningRepository(SwitchFullyIntakeAppContext context)
        {
            _context = context;
        }

        public async Task<Screening> AddNewScreeningToDatabase(Screening newScreening)
        {

            await _context.Screenings.AddAsync(newScreening);
            await _context.SaveChangesAsync();           
            return newScreening;
        }

        public async Task<List<Screening>> GetAllById(Guid id)
        {
            return await _context.Screenings.Where(p => p.JobApplicationId == id)
                .ToListAsync();
        }

        public async Task<Screening> FinalizeScreening(Screening lastScreening)
        {
            lastScreening.UpdateStatusToFalse();
            _context.Screenings.Update(lastScreening);
            await _context.SaveChangesAsync();
            return lastScreening;
        }
    }
}
