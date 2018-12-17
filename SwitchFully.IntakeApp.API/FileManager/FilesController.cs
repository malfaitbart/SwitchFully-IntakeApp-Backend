using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.Data.Repositories.FileUploads;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.FileManager
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilesController : ControllerBase
	{
		private readonly FileRepository _repo;

		public FilesController(FileRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<ActionResult<List<Domain.FileManagement.File>>> GetAll()
		{
			return Ok(await _repo.GetAll());
		}

		//[HttpPost, DisableRequestSizeLimit]
		//public async Task<IActionResult> UpLoad()
		//{
		//	try
		//	{
		//		var file = Request.Form.Files[0];
		//		var fileupload = new Domain.FileManagement.File();
		//		fileupload.ContentType = file.ContentType;
		//		fileupload.FileName = file.FileName;
		//		using (var memorystream = new MemoryStream())
		//		{
		//			await file.CopyToAsync(memorystream);
		//			fileupload.uploadedFile = memorystream.ToArray();
		//		}

		//		var result = await _repo.Create(fileupload);
		//		return Ok(result);
		//	}
		//	catch (Exception e)
		//	{
		//		return BadRequest(e.Message);
		//	}
		//}

		[HttpGet("{id}")]
		public async Task<IActionResult> Download(string id)
		{
			var file = await _repo.GetById(Guid.Parse(id));
			var filename = file.FileName;
			var fileContentResult = new FileContentResult(file.UploadedFile, file.ContentType)
			{
				FileDownloadName = filename
			};
			return fileContentResult;
		}
	}
}