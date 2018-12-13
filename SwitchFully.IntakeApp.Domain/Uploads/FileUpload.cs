using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.Uploads
{
	public class FileUpload
	{
		public Guid Id { get; set; }
		public string FileName { get; set; }
		public string ContentType { get; set; }
		public byte[] uploadedFile { get; set; }

		public FileUpload()
		{
			Id = Guid.NewGuid();
		}
	}
}
