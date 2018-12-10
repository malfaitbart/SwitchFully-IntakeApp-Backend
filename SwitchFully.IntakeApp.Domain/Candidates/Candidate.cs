using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.Candidates
{
	public class Candidate
	{
		private string id;
		private MailAddress mailAddress;

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

		public Candidate(string id, string firstName, string lastName, MailAddress mailAddress)
		{
			Id = Guid.Parse(id);
			FirstName = firstName;
			LastName = lastName;
			Email = mailAddress;
		}
	}
}
