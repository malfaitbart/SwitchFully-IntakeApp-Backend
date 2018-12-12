using SwitchFully.IntakeApp.Data.Repositories.Users;
using SwitchFully.IntakeApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.Users
{
	public class UserService : IUserService
	{
		private readonly UserRepository _userRepository;

		public UserService(UserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<string> Create(User user)
		{
			await _userRepository.Create(user);
			return user.Id.ToString();
		}

		public List<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task<User> GetById(Guid id)
		{
			return await _userRepository.GetById(id);
		}

		public string Update(User user)
		{
			throw new NotImplementedException();
		}
	}
}
