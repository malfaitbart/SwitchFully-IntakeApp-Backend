using SwitchFully.IntakeApp.Domain.Candidates;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SwitchFully.IntakeApp.Domain.Tests.Candidates
{
	public class CandidateTests
	{
		[Fact]
		public void GivenSomeData_CreateACandidate()
		{
			var candidate = new Candidate("test", "test", new System.Net.Mail.MailAddress("test@test.be"));

			Assert.IsType<Candidate>(candidate);
			Assert.Equal("test", candidate.FirstName);
			Assert.Equal("test", candidate.LastName);
			Assert.Equal("test@test.be", candidate.Email.Address);
		}
		[Fact]
		public void GivenSomeDataWithBadMailaddress_ThenExceptionIsThrown()
		{
			Action act = () =>
			{
				var candidate = new Candidate("test", "test", new System.Net.Mail.MailAddress("test"));
			};

			var exception = Assert.Throws<FormatException>(act);

			Assert.IsType<FormatException>(exception);
			Assert.Equal("The specified string is not in the form required for an e-mail address.",
				exception.Message);
		}
	}
}
