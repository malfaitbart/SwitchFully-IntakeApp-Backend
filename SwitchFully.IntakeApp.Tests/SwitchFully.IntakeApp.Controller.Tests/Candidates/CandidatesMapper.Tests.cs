using SwitchFully.IntakeApp.API.Candidates.Mapper;
using SwitchFully.IntakeApp.Domain.Candidates;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace SwitchFully.IntakeApp.Controller.Tests.Candidates
{
	public class CandidatesMapper
	{
		[Fact]
		public void GivenACandidateAndAMapper_WhenMappedToDto_DtoPropertiesAreCorrect()
		{
			//Given
			var _mapper = new CandidateMapper();
			var candidate = new Candidate("test", "test", new MailAddress("test@test.be"), "00000", "www.linkedin.be", "");

			//When
			var actual = _mapper.DomainToDto(candidate);

			//Then
			Assert.IsType<string>(actual.Id);
			Assert.IsType<string>(actual.Email);
			Assert.Equal("test@test.be", actual.Email);
		}
		[Fact]
		public void GivenACandidateDtoAndAMapper_WhenMappedToDto_DtoPropertiesAreCorrect()
		{
			//Given
			var _mapper = new CandidateMapper();
			var candidate = new Candidate("test", "test", new MailAddress("test@test.be"), "00000", "www.linkedin.be", "");
			var candidateDto = _mapper.DomainToDto(candidate);
			//When
			var actual = _mapper.DtoToDomain(candidateDto);

			//Then
			Assert.IsType<Guid>(actual.Id);
			Assert.IsType<MailAddress>(actual.Email);
			Assert.Equal("test@test.be", actual.Email.Address);
			Assert.Equal(candidate.Id, actual.Id);
		}
	}
}
