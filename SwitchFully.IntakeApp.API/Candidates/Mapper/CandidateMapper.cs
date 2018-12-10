using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using SwitchFully.IntakeApp.API.Candidates.DTO;
using SwitchFully.IntakeApp.Domain.Candidates;

namespace SwitchFully.IntakeApp.API.Candidates.Mapper
{
	public class CandidateMapper : ICandidateMapper
	{
		public CandidateDto DomainToDto(Candidate candidate)
		{
			return new CandidateDto
			{
				Id = candidate.Id.ToString(),
				FirstName = candidate.FirstName,
				LastName = candidate.LastName,
				Email = candidate.Email.Address
			};
		}

		public Candidate DtoToDomain(CandidateDto candidateDto)
		{
			return new Candidate(candidateDto.Id, candidateDto.FirstName, candidateDto.LastName, new MailAddress(candidateDto.Email));
		}
	}
}
