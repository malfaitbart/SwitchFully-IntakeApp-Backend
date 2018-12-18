using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess
{
    public class FinalDecision_Screening : Screening
    {
        private FinalDecision_Screening()
        {

        }
        public FinalDecision_Screening( string comment, Guid givenID) : base("FinalDecision", givenID, comment)
        {
            UpdateStatusToFalse();
        }

        public override Screening CreateNextScreening(Guid givenID, string givenComment)
        {
            return null;
        }

        public override void UpdateStatusToFalse()
        {
            this.Status = false;
        }
    }
}
