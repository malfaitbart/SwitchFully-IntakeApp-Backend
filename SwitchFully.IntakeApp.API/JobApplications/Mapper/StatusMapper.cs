using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using SwitchFully.IntakeApp.Domain.JobApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.JobApplications.Mapper
{
	public class StatusMapper
	{
		public StatusDto DomainToDto(Status status)
		{
			return new StatusDto
			{
				Id = status.Id,
				Description = status.Description
			};
		}

		public Status DtoToDomain(StatusDto statusDto)
		{
			return new Status(statusDto.Id, statusDto.Description);
		}
	}
}
