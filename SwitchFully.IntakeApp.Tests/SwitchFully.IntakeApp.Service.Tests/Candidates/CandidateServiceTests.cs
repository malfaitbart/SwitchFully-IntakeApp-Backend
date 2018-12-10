﻿using NSubstitute;
using SwitchFully.IntakeApp.Data.Repositories.Candidates;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Service.Candidates;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SwitchFully.IntakeApp.Service.Tests.Candidates
{
	public class CandidateServiceTests
	{
		[Fact]
		public void GivenACandidateService_WhenGetAll_GetAListOfCandidates()
		{
			//Given
			var mockRepo = Substitute.For<CandidateRepository>();
			var mockLogger = Substitute.For<ILoggerManager>();
			var _candidateService = new CandidateService(mockRepo, mockLogger);

			//When
			var actual = _candidateService.GetAll();

			//Then
			Assert.IsType<Task<List<Candidate>>>(actual);
		}
	}
}
 