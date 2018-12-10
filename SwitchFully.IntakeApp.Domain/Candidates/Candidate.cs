using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.Candidates
{
	public class Candidate
	{
		public Guid Id { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public MailAddress Email{ get; private set; }

		private Candidate()
		{
		}

		public Candidate(string firstName, string lastName, MailAddress email)
		{
			Id = Guid.NewGuid();
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}

		public Candidate(Guid id, string firstName, string lastName, MailAddress mailAddress)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			Email = mailAddress;
		}
	}
}
