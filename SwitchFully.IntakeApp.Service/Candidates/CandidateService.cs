using SwitchFully.IntakeApp.Data.Repositories.Candidates;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.Candidates
{
	public class CandidateService : ICandidateService
	{
		private readonly CandidateRepository _candidateRepository;
		private readonly ILoggerManager _loggerManager;

		public CandidateService(CandidateRepository candidateRepository, ILoggerManager loggerManager)
		{
			_candidateRepository = candidateRepository;
			_loggerManager = loggerManager;
		}

		public bool Delete(Candidate candidate)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Candidate>> GetAll()
		{
			_loggerManager.LogInfo("getting list of candidates from repository");
			return await _candidateRepository.GetAll();
		}

		public async Task<Candidate> GetById(string id)
		{
			_loggerManager.LogInfo($"Getting single candidate with id {id} from repository");
			return await _candidateRepository.GetById(Guid.Parse(id));
		}

		public Task<Candidate> Update(Candidate candidate)
		{
			throw new NotImplementedException();
		}

		public async Task<Candidate> Create(Candidate candidate)
		{
			_loggerManager.LogInfo($"Creating new candidate with id {candidate.Id.ToString()}");
			var returnedCandidate = await _candidateRepository.Create(candidate);
			if (returnedCandidate == null)
			{
				_loggerManager.LogError("unable to create candidate");
			}
			return returnedCandidate;
		}
	}
}
