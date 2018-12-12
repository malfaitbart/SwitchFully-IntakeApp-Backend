using SwitchFully.IntakeApp.Domain.JobApplications;
using System;
using Xunit;

namespace SwitchFully.IntakeApp.Domain.Tests.JobApplicationTests
{
	public class JobApplicationTests
	{
		[Fact]
		public void GivenSomeData_AJobApplicationCanBeMade()
		{
			var candidateId = Guid.NewGuid();
			var campagneId = Guid.NewGuid();
			var application = new JobApplication(candidateId, campagneId);

			Assert.Equal(candidateId, application.CandidateId);
			Assert.Equal(campagneId, application.CampaignId);
			Assert.Equal(0, application.StatusId);
		}
	}
}
