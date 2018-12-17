using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using SwitchFully.IntakeApp.API.JobApplications.Mapper;
using SwitchFully.IntakeApp.Domain.FileManagement;
using SwitchFully.IntakeApp.Service.JobApplications;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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

		public JobApplicationsController(JobApplicationMapper jobApplicationMapper, ILoggerManager loggerManager, IJobApplicationService jobApplicationService)
		{
			_jobApplicationMapper = jobApplicationMapper;
			_loggerManager = loggerManager;
			_jobApplicationService = jobApplicationService;
		}

		[HttpPost, DisableRequestSizeLimit]
		[Route("Upload")]
		public async Task<ActionResult<string>> UpLoad(string type)
		{
			var fileupload = new Domain.FileManagement.File();
			if (!Enum.IsDefined(typeof(FileType), type))
			{
				return BadRequest("Type must CV or Motivatie");
			}
			fileupload.SetType((FileType)Enum.Parse(typeof(FileType), type));

			try
			{
				var file = Request.Form.Files[0];
				fileupload.SetContentType(file.ContentType);
				fileupload.SetFileName(file.FileName);
				using (var memorystream = new MemoryStream())
				{
					await file.CopyToAsync(memorystream);
					fileupload.SetUploadedFile(memorystream.ToArray());
				}

				var result = _jobApplicationService.uploadFile(fileupload);
				return Ok(result.Id);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult<JobApplicationDto>> Create(JobApplicationDto_Create objectToCreate)
		{
			var toCreate = await _jobApplicationService.Create(_jobApplicationMapper.Dto_CreateToDomain(objectToCreate));
			return _jobApplicationMapper.DomainToDto(toCreate);
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
		public async Task<ActionResult<JobApplicationDto>> GetById(string id)
		{
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

			return Ok();

		}
	}
}