using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.API.Interfaces;
using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using SwitchFully.IntakeApp.API.JobApplications.Mapper;
using SwitchFully.IntakeApp.Domain.JobApplications;
using SwitchFully.IntakeApp.Service.JobApplications;
using SwitchFully.IntakeApp.Service.Logging;

namespace SwitchFully.IntakeApp.API.JobApplications.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobApplicationsController : ControllerBase
	{
		private readonly JobApplicationMapper _jobApplicationMapper;
		private readonly ILoggerManager _loggerManager;
		private readonly IJobApplicationService _jobApplicationService;

		public JobApplicationsController(JobApplicationMapper jobApplicationMapper, ILoggerManager loggerManager, IJobApplicationService jobApplicationService)
		{
			_jobApplicationMapper = jobApplicationMapper;
			_loggerManager = loggerManager;
			_jobApplicationService = jobApplicationService;
		}

		[HttpPost]
		public Task<ActionResult<JobApplicationDto>> Create(JobApplicationDto objectToCreate)
		{
			throw new NotImplementedException();
		}
		[HttpGet]
		public async Task<ActionResult<List<JobApplicationDto>>> GetAll()
		{
			var dtoList = new List<JobApplicationDto>();
			var getApplications = await _jobApplicationService.GetAll();
			foreach (var application in getApplications)
			{
				dtoList.Add(_jobApplicationMapper.DomainToDto(application));
			}
			_loggerManager.LogInfo("List of applications returned");
			return dtoList;
		}

		[HttpGet("{id}")]
		public Task<ActionResult<JobApplicationDto>> GetById(int id)
		{
			throw new NotImplementedException();
		}
		[HttpPut]
		public Task<ActionResult<JobApplicationDto>> Update(JobApplicationDto objectToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}