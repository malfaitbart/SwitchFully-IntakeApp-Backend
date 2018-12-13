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
		public async void GivenAJobApplicationService_WhenGetAll_ThenRepoExecutesGetAll()
		{
			//Given
			var mockRepo = Substitute.For<JobApplicationRepository>();
			var mockLogger = Substitute.For<ILoggerManager>();
			var _jobApplcaitionService = new JobApplicationService(mockRepo, mockLogger);

			//When
			await _jobApplcaitionService.GetAll();

			//Then
			await mockRepo.Received().GetAll();
		}

		[Fact]
		public async void GivenAJobApplicationService_WhenGetById_ThenRepoExecutesGetById()
		{
			//Given
			var mockRepo = Substitute.For<JobApplicationRepository>();
			var mockLogger = Substitute.For<ILoggerManager>();
			var _jobApplcaitionService = new JobApplicationService(mockRepo, mockLogger);
			var testGuid = Guid.NewGuid();
			//When
			await _jobApplcaitionService.GetById(testGuid.ToString());

			//Then
			await mockRepo.Received().GetById(testGuid);
		}

	}
}
