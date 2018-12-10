using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories.Candidates
{
	public class CandidateRepository : IRepository<Candidate>
	{
		private readonly SwitchFullyIntakeAppContext _context;

		public CandidateRepository()
		{
		}

		public CandidateRepository(SwitchFullyIntakeAppContext context)
		{
			_context = context;
		}

		public Task<Candidate> Create(Candidate objectToCreate)
		{
			throw new NotImplementedException();
		}

		public Task<List<Candidate>> GetAll()
		{
			return _context.Candidates.ToListAsync();
		}

		public Task<Candidate> GetById(Guid id)
		{
			return _context.Candidates.FirstOrDefaultAsync(c => c.Id == id);
		}

		public Task<Candidate> UpdateAsync(Candidate objectToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
