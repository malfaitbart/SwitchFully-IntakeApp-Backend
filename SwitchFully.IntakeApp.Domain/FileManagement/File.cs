using System;

namespace SwitchFully.IntakeApp.Domain.FileManagement
{
	public enum FileType
	{
		CV,
		Motivatie
	};
	public class File
	{

		public Guid Id { get; private set; }
		public FileType Type { get; private set; }
		public string FileName { get; private set; }
		public string ContentType { get; private set; }
		public byte[] UploadedFile { get; private set; }

		public  File()
		{
			Id = Guid.NewGuid();
		}

		public File(Guid id, string fileName)
		{
			Id = id;
			FileName = fileName;
		}

		public File(FileType type, string fileName, string contentType, byte[] uploadedFile)
		{
			Id = Guid.NewGuid();
			Type = type;
			FileName = fileName;
			ContentType = contentType;
			UploadedFile = uploadedFile;
		}
		public File(Guid id, FileType type, string fileName, string contentType, byte[] uploadedFile)
		{
			Id = id;
			Type = type;
			FileName = fileName;
			ContentType = contentType;
			UploadedFile = uploadedFile;
		}

		public void SetType(FileType fileType)
		{
			Type = fileType;
		}

		public void SetFileName(string fileName)
		{
			FileName = fileName;
		}

		public void SetContentType(string contentType)
		{
			ContentType = contentType;
		}

		public void SetUploadedFile(byte[] uploadedFile)
		{
			UploadedFile = uploadedFile;
		}
	}
}
