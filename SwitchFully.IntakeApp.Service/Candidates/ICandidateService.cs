using SwitchFully.IntakeApp.Domain.Candidates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.Candidates
{
	public interface ICandidateService
	{
		Task<List<Candidate>> GetAll();

		Task<Candidate> GetById(string id);

		Task<Candidate> Update(Candidate candidate);

		bool Delete(Candidate candidate);

		Task<Candidate> Create(Candidate candidate);
	}
}
