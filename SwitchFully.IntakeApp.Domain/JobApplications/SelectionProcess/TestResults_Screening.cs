using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess
{
    public class TestResults_Screening : Screening
    {
        private TestResults_Screening()
        {

        }

        public TestResults_Screening(string comment, Guid givenID) : base("TestResult", givenID, comment, typeof(FirstInterview_Screening).ToString())
        { 
        }

        public override Screening CreateNextScreening(Guid givenID, string givenComment)
        {
            UpdateStatusToFalse();
            return new FirstInterview_Screening( givenComment, givenID);
        }
        public override void UpdateStatusToFalse()
        {
            this.Status = false;
        }
    }
}
