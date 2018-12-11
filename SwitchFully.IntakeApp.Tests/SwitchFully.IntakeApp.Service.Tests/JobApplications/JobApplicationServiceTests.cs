using NSubstitute;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications;
using SwitchFully.IntakeApp.Service.JobApplications;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SwitchFully.IntakeApp.Service.Tests.JobApplications
{
	public class JobApplicationServiceTests
	{
		[Fact]
		public void GivenAJobApplicationService_WhenGetAll_ThenRepoExecutesGetAll()
		{
			//Given
			var mockRepo = Substitute.For<JobApplicationRepository>();
			var mockLogger = Substitute.For<ILoggerManager>();
			var _jobApplcaitionService = new JobApplicationService(mockRepo, mockLogger);

			//When
			_jobApplcaitionService.GetAll();

			//Then
			mockRepo.Received().GetAll();
		}

		[Fact]
		public void GivenAJobApplicationService_WhenGetById_ThenRepoExecutesGetById()
		{
			//Given
			var mockRepo = Substitute.For<JobApplicationRepository>();
			var mockLogger = Substitute.For<ILoggerManager>();
			var _jobApplcaitionService = new JobApplicationService(mockRepo, mockLogger);
			var testGuid = Guid.NewGuid();
			//When
			_jobApplcaitionService.GetById(testGuid.ToString());

			//Then
			mockRepo.Received().GetById(testGuid);
		}

	}
}
