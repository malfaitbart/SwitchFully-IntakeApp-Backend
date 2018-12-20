using NSubstitute;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications.Screenings;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using SwitchFully.IntakeApp.Service.JobApplications;
using SwitchFully.IntakeApp.Service.JobApplications.Screenings;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SwitchFully.IntakeApp.Service.Tests.Screenings
{
    public class ScreeningServiceTests
    {
        [Fact]
        public async void GivenGetAllScreeningsById_WhenRequestingAllScreenings_ThenReturnAllScreenings()
        {
            var testGuid = Guid.NewGuid();
            List<Screening> testScreen = new List<Screening>() { new CV_Screening("blabla", testGuid) };

            var mockRepo = Substitute.For<ScreeningRepository>();
            mockRepo.GetAllById(testGuid)
                .Returns(Task.FromResult(testScreen));
            var mockLogger = Substitute.For<ILoggerManager>();
            var mockJopApp = Substitute.For<IJobApplicationService>();
            var service = new ScreeningService(mockRepo, mockLogger, mockJopApp);

            var actualScreenings = await service.GetAllScreeningsById(testGuid.ToString());

            Assert.Equal(testScreen, actualScreenings);
        }

        [Fact]
        public async void GivenNewScreening_WhenAddingANewScreening_ThenNewScreeningIsAdded()
        {
            var testGuid = Guid.NewGuid();
            Screening testScreening = new CV_Screening("testtess", testGuid);
            List<Screening> testList = new List<Screening>();

            var mockRepo = Substitute.For<ScreeningRepository>();
            mockRepo.AddNewScreeningToDatabase(testScreening)
                .Returns(Task.FromResult(testScreening));
            mockRepo.GetAllById(testGuid)
                .Returns(Task.FromResult(testList));
            var mockLogger = Substitute.For<ILoggerManager>();
            var mockJopApp = Substitute.For<IJobApplicationService>();
            var service = new ScreeningService(mockRepo, mockLogger, mockJopApp);

            var actualScreenings = await service.NewScreening(testGuid.ToString(), testScreening.Comment);

            Assert.Single<Screening>(actualScreenings);
            Assert.Equal(testScreening.Comment, actualScreenings[0].Comment);
        }

        [Fact]
        public async void GivenNewScreeningWithOneScreeningInDatabase_WhenAddingASevondScreening_ThenSecondScreeningIsAdded()
        {
            var testGuid = Guid.NewGuid();
            Screening testScreening = new CV_Screening("testtess", testGuid);
            Screening testScreening2 = new Phone_Screening("ezqdsrezrez", testGuid);
            List<Screening> testList = new List<Screening>() { testScreening };

            var mockRepo = Substitute.For<ScreeningRepository>();
            mockRepo.AddNewScreeningToDatabase(testScreening2)
                .Returns(Task.FromResult(testScreening2));
            mockRepo.GetAllById(testGuid)
                .Returns(Task.FromResult(testList));
            var mockLogger = Substitute.For<ILoggerManager>();
            var mockJopApp = Substitute.For<IJobApplicationService>();
            var service = new ScreeningService(mockRepo, mockLogger, mockJopApp);

            var actualScreenings = await service.NewScreening(testGuid.ToString(), testScreening2.Comment);

            Assert.True(actualScreenings.Count == 2);
            Assert.Equal(testScreening2.Comment, actualScreenings[1].Comment);
            Assert.IsType<Phone_Screening>(actualScreenings[1]);
            Assert.False(actualScreenings[0].Status);
        }

        [Fact]
        public async void GivenNewScreeningWithTwoScreeningsInDatabase_WhenAddingAThirdScreening_ThenThirdScreeningIsAdded()
        {
            var testGuid = Guid.NewGuid();
            Screening testScreening = new CV_Screening("testtess", testGuid);
            testScreening.UpdateStatusToFalse();
            Screening testScreening2 = new Phone_Screening("ezqdsrezrez", testGuid);
            Screening testScreening3 = new TestResults_Screening("ezqdsrezrazezaeez", testGuid);
            List<Screening> testList = new List<Screening>() { testScreening, testScreening2 };

            var mockRepo = Substitute.For<ScreeningRepository>();
            mockRepo.AddNewScreeningToDatabase(testScreening3)
                .Returns(Task.FromResult(testScreening3));
            mockRepo.GetAllById(testGuid)
                .Returns(Task.FromResult(testList));
            var mockLogger = Substitute.For<ILoggerManager>();
            var mockJopApp = Substitute.For<IJobApplicationService>();
            var service = new ScreeningService(mockRepo, mockLogger, mockJopApp);

            var actualScreenings = await service.NewScreening(testGuid.ToString(), testScreening3.Comment);

            Assert.True(actualScreenings.Count == 3);
            Assert.Equal(testScreening3.Comment, actualScreenings[2].Comment);
            Assert.IsType<TestResults_Screening>(actualScreenings[2]);
            Assert.False(actualScreenings[1].Status);
        }

        [Fact]
        public async void GivenNewScreeningWithThreeScreeningsInDatabase_WhenAddingAFourthScreening_ThenFourthScreeningIsAdded()
        {
            var testGuid = Guid.NewGuid();
            Screening testScreening = new CV_Screening("testtess", testGuid);
            testScreening.UpdateStatusToFalse();
            Screening testScreening2 = new Phone_Screening("ezqdsrezrez", testGuid);
            testScreening2.UpdateStatusToFalse();
            Screening testScreening3 = new TestResults_Screening("ezqdsrezrazezaeez", testGuid);
            Screening testScreening4 = new FirstInterview_Screening("eblabla", testGuid);
            List<Screening> testList = new List<Screening>() { testScreening, testScreening2, testScreening3 };

            var mockRepo = Substitute.For<ScreeningRepository>();
            mockRepo.AddNewScreeningToDatabase(testScreening4)
                .Returns(Task.FromResult(testScreening4));
            mockRepo.GetAllById(testGuid)
                .Returns(Task.FromResult(testList));
            var mockLogger = Substitute.For<ILoggerManager>();
            var mockJopApp = Substitute.For<IJobApplicationService>();
            var service = new ScreeningService(mockRepo, mockLogger, mockJopApp);

            var actualScreenings = await service.NewScreening(testGuid.ToString(), testScreening4.Comment);

            Assert.True(actualScreenings.Count == 4);
            Assert.Equal(testScreening4.Comment, actualScreenings[3].Comment);
            Assert.IsType<FirstInterview_Screening>(actualScreenings[3]);
            Assert.False(actualScreenings[2].Status);
        }

        [Fact]
        public async void GivenNewScreeningWithFourScreeningsInDatabase_WhenAddingAFifthScreening_ThenFifthScreeningIsAdded()
        {
            var testGuid = Guid.NewGuid();
            Screening testScreening = new CV_Screening("testtess", testGuid);
            testScreening.UpdateStatusToFalse();
            Screening testScreening2 = new Phone_Screening("ezqdsrezrez", testGuid);
            testScreening2.UpdateStatusToFalse();
            Screening testScreening3 = new TestResults_Screening("ezqdsrezrazezaeez", testGuid);
            testScreening3.UpdateStatusToFalse();
            Screening testScreening4 = new FirstInterview_Screening("eblabla", testGuid);
            Screening testScreening5 = new GroupInterview_Screening("eblabdsdsfdsfla", testGuid);
            List<Screening> testList = new List<Screening>() { testScreening, testScreening2, testScreening3, testScreening4 };

            var mockRepo = Substitute.For<ScreeningRepository>();
            mockRepo.AddNewScreeningToDatabase(testScreening5)
                .Returns(Task.FromResult(testScreening5));
            mockRepo.GetAllById(testGuid)
                .Returns(Task.FromResult(testList));
            var mockLogger = Substitute.For<ILoggerManager>();
            var mockJopApp = Substitute.For<IJobApplicationService>();
            var service = new ScreeningService(mockRepo, mockLogger, mockJopApp);

            var actualScreenings = await service.NewScreening(testGuid.ToString(), testScreening5.Comment);

            Assert.True(actualScreenings.Count == 5);
            Assert.Equal(testScreening5.Comment, actualScreenings[4].Comment);
            Assert.IsType<GroupInterview_Screening>(actualScreenings[4]);
            Assert.False(actualScreenings[3].Status);
        }

        [Fact]
        public async void GivenNewScreeningWithFiveScreeningsInDatabase_WhenAddingSixthScreening_ThenSixthScreeningIsAdded()
        {
            var testGuid = Guid.NewGuid();
            var testJobApp = new JobApplication(testGuid, Guid.NewGuid(), Guid.NewGuid(), 4);

            Screening testScreening = new CV_Screening("testtess", testGuid);
            testScreening.UpdateStatusToFalse();
            Screening testScreening2 = new Phone_Screening("ezqdsrezrez", testGuid);
            testScreening2.UpdateStatusToFalse();
            Screening testScreening3 = new TestResults_Screening("ezqdsrezrazezaeez", testGuid);
            testScreening3.UpdateStatusToFalse();
            Screening testScreening4 = new FirstInterview_Screening("eblabla", testGuid);
            testScreening4.UpdateStatusToFalse();
            Screening testScreening5 = new GroupInterview_Screening("eblabdsdsfdsfla", testGuid);
            Screening testScreening6 = new FinalDecision_Screening("aangenome", testGuid);
            List<Screening> testList = new List<Screening>() { testScreening, testScreening2, testScreening3, testScreening4, testScreening5 };

            var mockRepo = Substitute.For<ScreeningRepository>();
            mockRepo.AddNewScreeningToDatabase(testScreening6)
                .Returns(Task.FromResult(testScreening6));
            mockRepo.GetAllById(testGuid)
                .Returns(Task.FromResult(testList));
            var mockLogger = Substitute.For<ILoggerManager>();
            var mockJopApp = Substitute.For<IJobApplicationService>();
            mockJopApp.UpdateStatusOfJobApplication(testGuid.ToString(),4)
                .Returns(Task.FromResult(testJobApp));
            var service = new ScreeningService(mockRepo, mockLogger, mockJopApp);

            var actualScreenings = await service.NewScreening(testGuid.ToString(), testScreening6.Comment);

            Assert.Equal(testJobApp.StatusId, 4);
            Assert.True(actualScreenings.Count == 6);
            Assert.Equal(testScreening6.Comment, actualScreenings[5].Comment);
            Assert.IsType<FinalDecision_Screening>(actualScreenings[5]);
            Assert.False(actualScreenings[4].Status);
            Assert.False(actualScreenings[5].Status);
        }


        [Fact]
        public async void GivenNewScreeningWithSixScreeningsInDatabase_WhenAddingSeventhhScreening_ThenListOfSixScreeningsIsReturned()
        {
            var testGuid = Guid.NewGuid();

            Screening testScreening = new CV_Screening("testtess", testGuid);
            testScreening.UpdateStatusToFalse();
            Screening testScreening2 = new Phone_Screening("ezqdsrezrez", testGuid);
            testScreening2.UpdateStatusToFalse();
            Screening testScreening3 = new TestResults_Screening("ezqdsrezrazezaeez", testGuid);
            testScreening3.UpdateStatusToFalse();
            Screening testScreening4 = new FirstInterview_Screening("eblabla", testGuid);
            testScreening4.UpdateStatusToFalse();
            Screening testScreening5 = new GroupInterview_Screening("eblabdsdsfdsfla", testGuid);
            testScreening5.UpdateStatusToFalse();
            Screening testScreening6 = new FinalDecision_Screening("aangenome", testGuid);
            testScreening6.UpdateStatusToFalse();
            List<Screening> testList = new List<Screening>() { testScreening, testScreening2, testScreening3, testScreening4, testScreening5, testScreening6 };

            var mockRepo = Substitute.For<ScreeningRepository>();
            mockRepo.GetAllById(testGuid)
                .Returns(Task.FromResult(testList));
            var mockLogger = Substitute.For<ILoggerManager>();
            var mockJopApp = Substitute.For<IJobApplicationService>();            
            var service = new ScreeningService(mockRepo, mockLogger, mockJopApp);

            var actualScreenings = await service.NewScreening(testGuid.ToString(), testScreening6.Comment);

            Assert.True(actualScreenings.Count == 6);
            Assert.Equal(testList, actualScreenings);           
        }
    }
}

