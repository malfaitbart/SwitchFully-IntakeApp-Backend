using SwitchFully.IntakeApp.API.Candidates.DTO;
using SwitchFully.IntakeApp.Domain.Candidates;

namespace SwitchFully.IntakeApp.API.Candidates.Mapper
{
	public interface ICandidateMapper
	{
		CandidateDto DomainToDto(Candidate candidate);
		Candidate DtoToDomain(CandidateDto candidateDto);
		Candidate DtoToDomain(CandidateDtoWithoutId candidateDto);
	}
}