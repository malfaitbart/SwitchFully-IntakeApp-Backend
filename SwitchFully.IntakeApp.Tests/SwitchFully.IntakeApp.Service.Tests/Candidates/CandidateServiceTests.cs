using NSubstitute;
using SwitchFully.IntakeApp.Data.Repositories.Candidates;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Service.Candidates;
using System;
using System.Collections.Generic;
using System.Text;
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
			var _candidateService = new CandidateService(mockRepo);

			//When
			var actual = _candidateService.GetAll();

			//Then
			Assert.IsType<List<Candidate>>(actual);
		}
	}
}
 