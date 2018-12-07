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

		public User Create(User objectToCreate)
		{
			_context.Add(objectToCreate);
			_context.SaveChangesAsync();
			return objectToCreate;
		}

		public List<User> GetAll()
		{
			return _context.Users.ToList();
		}

		public async Task<User> GetById(Guid id)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
		}

		public User Update(User objectToUpdate)
		{
			_context.Update(objectToUpdate);
			_context.SaveChangesAsync();
			return _context.Users.FirstOrDefault(u => u.Id == objectToUpdate.Id);
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
