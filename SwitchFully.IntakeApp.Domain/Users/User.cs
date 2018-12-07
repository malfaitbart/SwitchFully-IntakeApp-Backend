using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.Users
{
	public class User
	{
		public Guid Id { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public MailAddress Email { get; private set; }
		public UserSecurity SecurePassword { get; private set; }
		public int RoleId { get; private set; }
		public DateTime? LastLogon { get; private set; }

		private User() { }

		public User(string firstName, string lastName, MailAddress email, UserSecurity securePassword)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			SecurePassword = securePassword;
			RoleId = 1;
		}

		public User(Guid id, string firstName, string lastName, MailAddress email, UserSecurity securePassword, int roleId, DateTime lastLogon)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			SecurePassword = securePassword;
			RoleId = roleId;
			LastLogon = lastLogon;
		}

		public User(string firstName, string lastName, MailAddress email, UserSecurity securePassword, int roleId, DateTime lastLogon)
		{
			Id = Guid.NewGuid();
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			SecurePassword = securePassword;
			RoleId = roleId;
			LastLogon = lastLogon;
		}

		public void SetLastLogon()
		{
			LastLogon = DateTime.Now;
		}
	}
}
