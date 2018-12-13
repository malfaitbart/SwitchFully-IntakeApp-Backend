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
			var mockRepo = Substitute.For<CandidateRepository>();
			var mockLogger = Substitute.For<ILoggerManager>();
			var _candidateService = new CandidateService(mockRepo, mockLogger);

			//When
			var actual = await _candidateService.GetAll();

			//Then
			await Assert.IsType<Task<List<Candidate>>>(actual);
		}

		[Fact]
		public async void GivenACandidate_WhenGetById_ThenRepoExecutesGetById()
		{
			//Given
			var mockRepo = Substitute.For<CandidateRepository>();
			var mockLogger = Substitute.For<ILoggerManager>();
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
			var mockRepo = Substitute.For<CandidateRepository>();
			var mockLogger = Substitute.For<ILoggerManager>();
			var _candidateService = new CandidateService(mockRepo, mockLogger);
			var candidate = new Candidate("test", "test", new MailAddress("test@test"), "00000", "www.linkedin.be", "");
			//When
			await _candidateService.Create(candidate);

			//Then
			await mockRepo.Received().Create(candidate);
		}
	}
}
