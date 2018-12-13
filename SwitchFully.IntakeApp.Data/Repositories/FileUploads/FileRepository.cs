using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.Uploads;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories.FileUploads
{
	public class FileRepository : IRepository<FileUpload>
	{
		private readonly SwitchFullyIntakeAppContext _context;

		public FileRepository(SwitchFullyIntakeAppContext context)
		{
			_context = context;
		}

		public async Task<FileUpload> Create(FileUpload objectToCreate)
		{
			await _context.AddAsync(objectToCreate);
			await _context.SaveChangesAsync();
			return await GetById(objectToCreate.Id);
		}

		public async Task<List<FileUpload>> GetAll()
		{
			return await _context.FileUploads.ToListAsync();
		}

		public async Task<FileUpload> GetById(Guid id)
		{
			return await _context.FileUploads.FirstOrDefaultAsync(fu => fu.Id == id);
		}

		public Task<FileUpload> Update(FileUpload objectToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
