using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories
{
	public class UserRepository : IRepository<User>
	{
		private readonly SwitchFullyIntakeAppContext _context;

		public UserRepository(SwitchFullyIntakeAppContext context)
		{
			_context = context;
		}

		public async Task<User> Create(User objectToCreate)
		{
			_context.Add(objectToCreate);
			await _context.SaveChangesAsync();
			return objectToCreate;
		}

		public async Task<List<User>> GetAll()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User> GetById(Guid id)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<User> UpdateAsync(User objectToUpdate)
		{
			_context.Update(objectToUpdate);
			await _context.SaveChangesAsync();
			return await _context.Users.FirstOrDefaultAsync(u => u.Id == objectToUpdate.Id);
		}

		public User FindByEmail(string providedEmail)
		{
			return _context.Users.FirstOrDefault(u => u.Email.Address == providedEmail);
		}

		public void SetLastLogon(User foundUser)
		{
			_context.Attach(foundUser);
			foundUser.SetLastLogon();
			_context.SaveChanges();
		}
	}
}
