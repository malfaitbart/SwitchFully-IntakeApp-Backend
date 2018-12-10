using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.Candidates;
using System;
using System.Collections.Generic;
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

		public async Task<Candidate> Create(Candidate objectToCreate)
		{
			await _context.AddAsync(objectToCreate);
			if (await _context.SaveChangesAsync() == 0)
			{
				throw new Exception("Candidate not created");
			}
			return await GetById(objectToCreate.Id);
		}

		public Task<List<Candidate>> GetAll()
		{
			return _context.Candidates.ToListAsync();
		}

		public async Task<Candidate> GetById(Guid id)
		{
			return await _context.Candidates.FirstOrDefaultAsync(c => c.Id == id);
		}

		public Task<Candidate> UpdateAsync(Candidate objectToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
