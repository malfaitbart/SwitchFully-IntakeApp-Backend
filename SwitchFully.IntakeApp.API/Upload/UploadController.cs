using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.Data.Repositories;
using SwitchFully.IntakeApp.Data.Repositories.FileUploads;
using SwitchFully.IntakeApp.Domain.Uploads;

namespace SwitchFully.IntakeApp.API.Upload
{
	[Route("api/[controller]")]
	[ApiController]
	public class UploadController : ControllerBase
	{
		private readonly FileRepository _repo;

		public UploadController(FileRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<ActionResult<List<FileUpload>>> GetAll()
		{
			return Ok(await _repo.GetAll());
		}

		[HttpPost, DisableRequestSizeLimit]
		public async Task<IActionResult> UpLoad()
		{
			try
			{
				var file = Request.Form.Files[0];
				var fileupload = new FileUpload();
				fileupload.ContentType = file.ContentType;
				fileupload.FileName = file.FileName;
				using (var memorystream = new MemoryStream())
				{
					await file.CopyToAsync(memorystream);
					fileupload.uploadedFile = memorystream.ToArray();
				}

				var result  = await _repo.Create(fileupload);
				return Ok(result);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}