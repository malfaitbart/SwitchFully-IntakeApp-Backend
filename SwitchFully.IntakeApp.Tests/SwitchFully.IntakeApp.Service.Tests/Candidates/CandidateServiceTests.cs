using NSubstitute;
using SwitchFully.IntakeApp.Data.Repositories.Candidates;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Service.Candidates;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using Xunit;

namespace SwitchFully.IntakeApp.Service.Tests.Candidates
{
	public class CandidateServiceTests
	{
        [Fact]
        public async void GivenACandidateService_WhenGetAll_GetAListOfCandidates()
        {
            //Given
            List<Candidate> candidates = new List<Candidate>() {
                new Candidate("test", "test", new MailAddress("test@test"), "00000", "www.linkedin.be", "")
            };
			var mockRepo = Substitute.For<CandidateRepository>();
            mockRepo.GetAll()
                .Returns(Task.FromResult(candidates));
			var mockLogger = Substitute.For<ILoggerManager>();
			var _candidateService = new CandidateService(mockRepo, mockLogger);

			//When
			var actual = await _candidateService.GetAll();

            //Then
            Assert.Equal(candidates, actual);
        }

		[Fact]
		public async void GivenACandidate_WhenGetById_ThenRepoExecutesGetById()
		{
			//Given
			var mockRepo = Substitute.For<CandidateRepository>();
			var mockLogger = Substitute.For<ILoggerManager>();
            mockRepo.GetById(Guid.NewGuid())
                .Returns(Task.FromResult(new Candidate("test", "test", new MailAddress("test@test"), "00000", "www.linkedin.be", "")));
			var _candidateService = new CandidateService(mockRepo, mockLogger);
			var testGuid = Guid.NewGuid();
			//When
			await _candidateService.GetById(testGuid.ToString());

			//Then
			await mockRepo.Received().GetById(testGuid);
		}

        [Fact]
        public async void GivenACandidateAnACandidateService_WhenCreate_ThenRepoExecutesCreateWithThatCandite()
        {
            //Given
            var candidate = new Candidate("test", "test", new MailAddress("test@test"), "00000", "www.linkedin.be", "");
            var mockRepo = Substitute.For<CandidateRepository>();
            mockRepo.Create(candidate)
                .Returns(Task.FromResult(candidate));
            var mockLogger = Substitute.For<ILoggerManager>();
            var _candidateService = new CandidateService(mockRepo, mockLogger);


            //When
            await _candidateService.Create(candidate);

            //Then
            await mockRepo.Received().Create(candidate);
        }
    }
}
