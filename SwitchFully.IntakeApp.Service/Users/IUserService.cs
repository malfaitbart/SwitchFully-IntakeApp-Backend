using System;
using System.Collections.Generic;
using System.Text;
using SwitchFully.IntakeApp.Domain.Users;

namespace SwitchFully.IntakeApp.Service.Users
{
	public interface IUserService
	{
		string Create(User user);
		User GetById(Guid id);
		List<User> GetAll();
		string Update(User user);
	}
}
