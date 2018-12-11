using System;

namespace SwitchFully.IntakeApp.API.Users.Dto
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public DateTime LastLogon { get; set; }
	}
}
