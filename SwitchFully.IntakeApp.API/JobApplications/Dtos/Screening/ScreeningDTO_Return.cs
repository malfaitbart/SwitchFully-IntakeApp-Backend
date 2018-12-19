using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.JobApplications.Dtos
{
	public class ScreeningDTO_Return
	{
        public string Name { get;  set; }
        public string NextScreeningType { get;  set; }
        public bool Status { get;  set; }
        public string Comment { get;  set; }
        public Guid JobApplicationId { get;  set; }
        public string AuditUser { get;  set; }
        public DateTime AuditDateTime { get;  set; }
    }
}
