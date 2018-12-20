using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories.JobApplications.Screenings
{
	public class ScreeningRepository : IScreeningRepository
	{
		private readonly SwitchFullyIntakeAppContext _context;

		public ScreeningRepository()
		{ }

		public ScreeningRepository(SwitchFullyIntakeAppContext context)
		{
			_context = context;
		}

		public virtual async Task<Screening> AddNewScreeningToDatabase(Screening newScreening)
		{

			await _context.Screenings.AddAsync(newScreening);
			await _context.SaveChangesAsync();
			return newScreening;
		}

		public async Task<string> GetActiveScreeningStepForJobApplicationId(Guid id)
		{
			return await _context.Screenings
				.Where(s => s.JobApplicationId == id)
				.Where(s => s.Status == true || s.NextScreeningType == "Done")
				.Select(s => s.NextScreeningType)
				.FirstOrDefaultAsync();
		}

		public virtual async Task<List<Screening>> GetAllById(Guid id)
		{
			return await _context.Screenings
				.Where(p => p.JobApplicationId == id)
				.OrderBy(p => p.Order)
				.ToListAsync();
		}
	}
}
