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
		public string Phone { get; private set; }
		public string LinkedIn { get; private set; }
		public string Comment { get; private set; }
		private Candidate()
		{
		}

		public Candidate(string firstName, string lastName, MailAddress email, string phone, string linkedin, string comment)
		{
			Id = Guid.NewGuid();
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Phone = phone;
			LinkedIn = linkedin;
			Comment = comment;
		}

		public Candidate(Guid id, string firstName, string lastName, MailAddress mailAddress, string phone, string linkedin, string comment)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			Email = mailAddress;
			Phone = phone;
			LinkedIn = linkedin;
			Comment = comment;
		}
	}
}
