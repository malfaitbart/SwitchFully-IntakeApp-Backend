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
			var application = new JobApplication(candidateId, campagneId, 1);

			Assert.Equal(candidateId, application.CandidateId);
			Assert.Equal(campagneId, application.CampagneId);
			Assert.Equal(1, application.StatusId);
		}
	}
}
