using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.FileManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories.FileUploads
{
	public class FileRepository : IRepository<File>
	{
		private readonly SwitchFullyIntakeAppContext _context;

		public FileRepository(SwitchFullyIntakeAppContext context)
		{
			_context = context;
		}

		public FileRepository()
		{
		}

		public async Task<File> Create(File objectToCreate)
		{
			await _context.AddAsync(objectToCreate);
			await _context.SaveChangesAsync();
			return await GetById(objectToCreate.Id);
		}

		public async Task<List<File>> GetAll()
		{
			return await _context.FileUploads
				.Select(fu => new File(fu.Id,fu.FileName))
				.ToListAsync();
		}

		public async Task<File> GetById(Guid id)
		{
			return await _context.FileUploads.FirstOrDefaultAsync(fu => fu.Id == id);
		}

		public Task<File> Update(File objectToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
