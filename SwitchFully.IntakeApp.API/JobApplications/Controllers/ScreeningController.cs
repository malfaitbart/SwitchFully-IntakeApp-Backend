using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using SwitchFully.IntakeApp.API.JobApplications.Mapper;
using SwitchFully.IntakeApp.Service.JobApplications.Screenings;
using SwitchFully.IntakeApp.Service.Logging;

namespace SwitchFully.IntakeApp.API.JobApplications.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class ScreeningController : Controller
    {
        private readonly IScreeningMapper _screeningMapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IScreeningService _screeningService;

        public ScreeningController(IScreeningMapper screeningMapper, ILoggerManager loggerManager, IScreeningService screeningService)
        {
            _screeningMapper = screeningMapper;
            _loggerManager = loggerManager;
            _screeningService = screeningService;
        }


        // GET: api/Screening
        [HttpGet]
        [Route("{id}")]
        public async Task<List<ScreeningDTO_Return>> GetAll(string id)
        {
            return _screeningMapper.FromScreeningListToScreeningDTOReturnList( await _screeningService.GetAllScreeningsById(id));
        }

       
        // POST: api/Screening
        [HttpPost]
        [Route("{id}")]
        public async Task<List<ScreeningDTO_Return>> Post(string id, ScreeningDTO_Create screeningDTO)
        {
            var newSceeningList = await _screeningService.NewScreening(id, screeningDTO.Comment);
            return _screeningMapper.FromScreeningListToScreeningDTOReturnList(newSceeningList);
        }
      
    }
}
