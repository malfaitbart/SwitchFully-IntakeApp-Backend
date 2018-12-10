using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SwitchFully.IntakeApp.Domain.Users;

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
