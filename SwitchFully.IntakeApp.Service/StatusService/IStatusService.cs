using SwitchFully.IntakeApp.Domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Service.StatusService
{
	public interface IStatusService
	{
		Status GetById(int id);
	}
}
