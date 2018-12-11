using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.JobApplications.Dtos
{
	public class ScreeningDto
	{
		public int Id { get; private set; }
		public string Type { get; private set; }
		public string Comment { get; private set; }
		public bool IsActive { get; private set; }
		public int Order { get; private set; }

	}
}
