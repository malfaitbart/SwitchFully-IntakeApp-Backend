using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.Users.Dto
{
	public class UserRegisterDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public UserRegisterDto(string firstName, string lastName, string email, string password)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Password = password;
		}
	}
}
