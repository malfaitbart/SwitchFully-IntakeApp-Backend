using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using SwitchFully.IntakeApp.API.JobApplications.Dtos.JobApplication;
using SwitchFully.IntakeApp.API.JobApplications.Mapper;
using SwitchFully.IntakeApp.Service.JobApplications;
using SwitchFully.IntakeApp.Service.JobApplications.Screenings;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.JobApplications.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class JobApplicationsController : Controller
	{
		private readonly JobApplicationMapper _jobApplicationMapper;
		private readonly ILoggerManager _loggerManager;
		private readonly IJobApplicationService _jobApplicationService;
		private readonly IScreeningService _screeningService;

		public JobApplicationsController(JobApplicationMapper jobApplicationMapper, ILoggerManager loggerManager, IJobApplicationService jobApplicationService, IScreeningService screeningService)
		{
			_jobApplicationMapper = jobApplicationMapper;
			_loggerManager = loggerManager;
			_jobApplicationService = jobApplicationService;
			_screeningService = screeningService;
		}

		[HttpPost]
		public async Task<ActionResult<JobApplicationDto>> Create(JobApplicationDto_Create objectToCreate)
		{
			var toCreate = await _jobApplicationService.Create(_jobApplicationMapper.Dto_CreateToDomain(objectToCreate));
			_loggerManager.LogInfo($"jobapplication created with id {toCreate.Id}");
			return _jobApplicationMapper.DomainToDto(toCreate);
		}

		[HttpGet]
		public async Task<ActionResult<List<JobApplicationDto_Overview>>> GetAll()
		{
			var dtoList = new List<JobApplicationDto_Overview>();
			var getApplications = await _jobApplicationService.GetAll();
			foreach (var application in getApplications)
			{
				var selectionStep = await _screeningService.GetActiveScreeningStepForJobApplicationId(application.Id);
				if (string.IsNullOrEmpty(selectionStep))
				{
					selectionStep = "CV";
				}
				dtoList.Add(_jobApplicationMapper.DomainToDto_Overview(application, selectionStep));
			}
			_loggerManager.LogInfo("List of jobapplications returned");
			return dtoList;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<JobApplicationDto>> GetById(string id)
		{
			_loggerManager.LogInfo($"jobapplication returned with id {id}");
			return _jobApplicationMapper.DomainToDto(await _jobApplicationService.GetById(id));
		}

		[HttpPut]
		public Task<ActionResult<JobApplicationDto>> Update(JobApplicationDto objectToUpdate)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		[Route("reject/id:string")]
		public async Task<ActionResult> Reject(string id)
		{
			var jobApplicationByID = await _jobApplicationService.GetById(id);
			if (jobApplicationByID == null)
			{ return BadRequest("ID not found"); }
			await _jobApplicationService.RejectJobApplication(jobApplicationByID);
			_loggerManager.LogInfo($"jobapplication with id {id} is rejected");
			return Ok();
		}
	}
}