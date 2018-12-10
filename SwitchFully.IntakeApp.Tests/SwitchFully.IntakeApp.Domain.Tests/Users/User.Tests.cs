using SwitchFully.IntakeApp.Domain.Users;
using System;
using Xunit;

namespace SwitchFully.IntakeApp.Domain.Tests.Users
{
	public class UserTest
	{
		[Fact]
		public void GivenSomeData_CreateUser()
		{
			var user = new User("bart", "malfait", new System.Net.Mail.MailAddress("malfaitbart@gmail.com"),
				new UserSecurity("pass", "salt"));

			Assert.IsType<User>(user);
			Assert.Equal("bart", user.FirstName);
			Assert.Equal("malfait", user.LastName);
			Assert.Equal("malfaitbart@gmail.com", user.Email.Address);
			Assert.Equal("pass", user.SecurePassword.PasswordHash);
			Assert.Equal(1, user.RoleId);
			Assert.Null(user.LastLogon);
		}
	}
}
