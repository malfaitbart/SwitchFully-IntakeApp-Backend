using SwitchFully.IntakeApp.API.Users.Dto;
using SwitchFully.IntakeApp.Domain.Users;
using SwitchFully.IntakeApp.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.Users.Mapper
{
	public class UserMapper
	{
		private readonly UserAuthenticationService _userService;

		public UserMapper(UserAuthenticationService userService)
		{
			_userService = userService;
		}

		public User UserRegisterDtoToDomain(UserRegisterDto userRegisterDto)
		{
			var user = new User(
				userRegisterDto.FirstName,
				userRegisterDto.LastName,
				new MailAddress(userRegisterDto.Email),
				_userService.CreateUserSecurity(userRegisterDto.Password)
				);
			return user;
		}

		internal UserDto UserToUserDto(User user)
		{
			var userDto = new UserDto
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email.Address
			};
			return userDto;
		}
	}
}
