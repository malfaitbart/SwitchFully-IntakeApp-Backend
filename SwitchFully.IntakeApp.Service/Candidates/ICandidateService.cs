using SwitchFully.IntakeApp.Domain.Candidates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.Candidates
{
	public interface ICandidateService
	{
		Task<List<Candidate>> GetAll();

		Task<Candidate> GetById(string id);

		Candidate Update(Candidate candidate);

		bool Delete(Candidate candidate);
	}
}
