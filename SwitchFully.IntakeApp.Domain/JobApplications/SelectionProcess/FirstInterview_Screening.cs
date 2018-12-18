using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess
{
    public class FirstInterview_Screening : Screening
    {
        private FirstInterview_Screening()
        {

        }

        public FirstInterview_Screening(string comment, Guid givenID) : base("FirstInterview", givenID, comment)
        {
        }

        public override Screening CreateNextScreening(Guid givenID, string givenComment)
        {
            UpdateStatusToFalse();
            return new GroupInterview_Screening(givenComment, givenID);
        }

        public override void UpdateStatusToFalse()
        {
            this.Status = false;
        }
    }
}
