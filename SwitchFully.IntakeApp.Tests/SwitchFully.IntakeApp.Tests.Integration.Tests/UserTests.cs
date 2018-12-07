using Microsoft.Extensions.Configuration;
using SwitchFully.IntakeApp.Data.Repositories;
using SwitchFully.IntakeApp.Domain.Users;
using SwitchFully.IntakeApp.Service.Security;
using System.Net.Mail;
using Xunit;

namespace SwitchFully.IntakeApp.Tests.Integration.Tests
{
	public class UserTests
	{
		private IConfiguration _config;
		[Fact]
		public void GivenUserData_AUserCanBeCreated()
		{
			//var user = new User(
			//	"bart",
			//	"malfait",
			//	new MailAddress("malfaitbart@gmail.com"),
			//	_userAuthenticationService.CreateUserSecurity("pass")
			//);

			//Assert.IsType<User>(user);
			//Assert.NotNull(user.SecurePassword.PasswordHash);
			//Assert.NotEqual("pass", user.SecurePassword.PasswordHash);
		}
	}
}
