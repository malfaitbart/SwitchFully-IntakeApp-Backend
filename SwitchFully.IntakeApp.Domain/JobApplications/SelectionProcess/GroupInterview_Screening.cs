using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess
{
    public class GroupInterview_Screening : Screening
    {
        private GroupInterview_Screening()
        {

        }

        public GroupInterview_Screening( string comment, Guid givenID) : base("GroupInterview", givenID,comment, typeof(FinalDecision_Screening).ToString(), 5)
        {
        }      

        public override Screening CreateNextScreening(Guid givenID, string givenComment)
        {
            UpdateStatusToFalse();
            return new FinalDecision_Screening(givenComment, givenID);
        }
        public override void UpdateStatusToFalse()
        {
            this.Status = false;
        }
    }
}
