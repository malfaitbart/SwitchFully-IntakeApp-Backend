namespace SwitchFully.IntakeApp.Domain.Users
{
	public class UserSecurity
	{
		public string PasswordHash { get; set; }
		public string Salt { get; set; }

		public UserSecurity(string passwordHash, string salt)
		{
			PasswordHash = passwordHash;
			Salt = salt;
		}
	}
}