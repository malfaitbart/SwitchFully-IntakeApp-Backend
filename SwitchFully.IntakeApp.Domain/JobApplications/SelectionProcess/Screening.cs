using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess
{
    public abstract class Screening
    {

        public string Name { get; private set; }
        public bool Status { get; protected set; }
        public string Comment { get; private set; }

        public JobApplication JobApplication { get; private set; }
        public Guid JobApplicationId { get; private set; }
        

        public string AuditUser { get; private set; }
        public DateTime AuditDateTime { get; private set; }

        protected Screening() { }

        protected Screening(string name, Guid givenID, string comment)
        {
            Name = name;
            Status = true;
            Comment = comment;
            JobApplicationId = givenID;

            AuditUser = "temp";
            AuditDateTime = DateTime.Now;

        }

        public abstract Screening CreateNextScreening(Guid givenID, string givenComment);


        public abstract void UpdateStatusToFalse();      
    }
}
