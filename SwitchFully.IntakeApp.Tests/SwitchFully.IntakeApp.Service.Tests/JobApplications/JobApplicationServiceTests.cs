using NSubstitute;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Service.JobApplications;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            List<JobApplication> expectedJobApplications = new List<JobApplication>() {
                new JobApplication(Guid.NewGuid(), Guid.NewGuid())
            };
            mockRepo.GetAll()
                .Returns(Task.FromResult(expectedJobApplications));
            var mockLogger = Substitute.For<ILoggerManager>();
			var _jobApplcaitionService = new JobApplicationService(mockRepo, mockLogger);

			//When
			var actualJobApplications = await _jobApplcaitionService.GetAll();

            //Then
            Assert.Equal(expectedJobApplications, actualJobApplications);
		}

		[Fact]
		public async void GivenAJobApplicationService_WhenGetById_ThenRepoExecutesGetById()
		{
			//Given
			var testGuid = Guid.NewGuid();
			var mockRepo = Substitute.For<JobApplicationRepository>();
            mockRepo.GetById(testGuid)
                .Returns(Task.FromResult(new JobApplication(Guid.NewGuid(), Guid.NewGuid())));
            var mockLogger = Substitute.For<ILoggerManager>();
			var _jobApplcaitionService = new JobApplicationService(mockRepo, mockLogger);
			//When
			await _jobApplcaitionService.GetById(testGuid.ToString());

			//Then
			await mockRepo.Received().GetById(testGuid);
		}

		[Fact]
		public async void GivenCreateNewJobApplication_WhenCreatingNewJobApplication_ThenNewJobApplicationIsCreated()
		{
            var testJobApp = new JobApplication(Guid.NewGuid(), Guid.NewGuid());
			//Given
			var mockRepo = Substitute.For<JobApplicationRepository>();
            mockRepo.Create(testJobApp)
                .Returns(Task.FromResult(testJobApp));
            var mockLogger = Substitute.For<ILoggerManager>();
			var _jobApplcaitionService = new JobApplicationService(mockRepo, mockLogger);
            //When
            var createdJobapp = await _jobApplcaitionService.Create(testJobApp);


            //Then
            Assert.Equal(createdJobapp, testJobApp);
		}

        [Fact]
        public async void GivenRejectJobApplication_WhenRejectingAJobApplication_ThenJobApplicationIsRejected()
        {
            var testGuid = Guid.NewGuid();
            var testJobApp = new JobApplication(testGuid, Guid.NewGuid(), Guid.NewGuid(), 2);

            //Given
            var mockRepo = Substitute.For<JobApplicationRepository>();
            mockRepo.Update(testJobApp)
                .Returns(Task.FromResult(testJobApp));
            var mockLogger = Substitute.For<ILoggerManager>();
            var _jobApplcaitionService = new JobApplicationService(mockRepo, mockLogger);
            //When
            await _jobApplcaitionService.RejectJobApplication(testJobApp);


            //Then
            Assert.True(testJobApp.StatusId == 3);
        }



    }
}
