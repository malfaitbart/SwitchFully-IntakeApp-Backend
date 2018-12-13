
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using SwitchFully.IntakeApp.API.Candidates.DTO;
using SwitchFully.IntakeApp.API.Candidates.Mapper;
using SwitchFully.IntakeApp.Domain.Candidates;
using SwitchFully.IntakeApp.Service.Candidates;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.Candidates.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _candidateService;
        private readonly ILoggerManager _loggerManager;
        private readonly ICandidateMapper _candidateMapper;
        private IHostingEnvironment _hostingEnvironment;

        public CandidatesController(ICandidateService candidateService, ILoggerManager loggerManager, ICandidateMapper candidateMapper, IHostingEnvironment hostingEnvironment)
        {
            _candidateService = candidateService;
            _loggerManager = loggerManager;
            _candidateMapper = candidateMapper;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<ActionResult<CandidateDto>> Create(CandidateDtoWithoutId objectToCreate)
        {
            var created = await _candidateService.Create(_candidateMapper.DtoToDomain(objectToCreate));
            return _candidateMapper.DomainToDto(created);
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDto>> GetById(string id)
        {
            var candidate = await _candidateService.GetById(id);
            return _candidateMapper.DomainToDto(candidate);
        }

        [HttpPut]
        public Task<ActionResult<CandidateDto>> Update(CandidateDto objectToUpdate)
        {
            throw new NotImplementedException();
        }

    }


}
