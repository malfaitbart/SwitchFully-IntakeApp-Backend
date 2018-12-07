using System;
using System.Collections.Generic;
using System.Text;
using SwitchFully.IntakeApp.Data.Repositories;
using SwitchFully.IntakeApp.Domain.Users;

namespace SwitchFully.IntakeApp.Service.Users
{
	public class UserService : IUserService
	{
		private readonly UserRepository _userRepository;

		public UserService(UserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public string Create(User user)
		{
			_userRepository.Create(user);
			return user.Id.ToString();
		}

		public List<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public User GetById(Guid id)
		{
			return _userRepository.GetById(id);
		}

		public string Update(User user)
		{
			throw new NotImplementedException();
		}
	}
}
