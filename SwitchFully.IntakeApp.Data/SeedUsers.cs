using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Domain.Users;
using System.Net.Mail;
namespace SwitchFully.IntakeApp.Data
{
	public partial class SwitchFullyIntakeAppContext
	{
		//private readonly UserAuthenticationService _userAuthenticationService;

		//public SwitchFullyIntakeAppContext(UserAuthenticationService userAuthenticationService)
		//{
		//	_userAuthenticationService = userAuthenticationService;
		//}

		protected void SeedUsers(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(u =>
				{
					//u.HasData(new User("Bart", "Malfait", new MailAddress("malfaitbart@gmail.com"),));
					//u.HasData(new User("Willem", "Polfliet", new MailAddress("willem.polfliet@cegeka.com"),));
					//u.HasData(new User("Lars", "Peelman", new MailAddress("lars.peelman@hotmail.com"),));
					//u.HasData(new User("Niels", "Delestinne", new MailAddress("nielsdelestinne@gmail.com"),));
					//u.HasData(new User("Reinout", "Van Bets", new MailAddress("reinoutvanbets@gmail.com"),));
				});
		}
	}
}
