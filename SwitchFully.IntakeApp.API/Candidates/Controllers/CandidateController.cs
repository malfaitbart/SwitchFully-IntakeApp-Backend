using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.API.Candidates.DTO;
using SwitchFully.IntakeApp.API.Candidates.Mapper;
using SwitchFully.IntakeApp.API.Interfaces;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Service.Candidates;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.Candidates.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class CandidateController : ControllerBase
	{
		private readonly CandidateService _candidateService;
		private readonly ILoggerManager _loggerManager;
		private readonly ICandidateMapper _candidateMapper;

		public CandidateController(CandidateService candidateService, ILoggerManager loggerManager, ICandidateMapper candidateMapper)
		{
			_candidateService = candidateService;
			_loggerManager = loggerManager;
			_candidateMapper = candidateMapper;
		}
		[HttpPost]
		public Task<ActionResult<CandidateDto>> Create(Candidate objectToCreate)
		{
			throw new NotImplementedException();
		}
		[HttpGet]
		public async Task<ActionResult<List<CandidateDto>>> GetAll()
		{
			var dtoList = new List<CandidateDto>();
			var getCandidates = await _candidateService.GetAll();
			foreach (var candidate in getCandidates)
			{
				dtoList.Add(_candidateMapper.DomainToDto(candidate));
			}
			_loggerManager.LogInfo("List of candidates returned");
			return dtoList;
		}

		[HttpGet]
		[Route("id:string")]
		public Task<ActionResult<CandidateDto>> GetById(string id)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		public Task<ActionResult<CandidateDto>> Update(CandidateDto objectToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}