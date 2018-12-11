using SwitchFully.IntakeApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.Users
{
	public interface IUserService
	{
		string Create(User user);
		Task<User> GetById(Guid id);
		List<User> GetAll();
		string Update(User user);
	}
}
