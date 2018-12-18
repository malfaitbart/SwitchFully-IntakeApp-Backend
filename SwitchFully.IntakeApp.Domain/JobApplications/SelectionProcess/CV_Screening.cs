using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess
{
    public class CV_Screening : Screening
    {
        private CV_Screening() 
        {

        }

        public CV_Screening(string comment, Guid givenID) : base("CV" , givenID , comment)
        {

        }

        public override Screening CreateNextScreening(Guid givenID,string givenComment)
        {
            UpdateStatusToFalse();
            return new Phone_Screening(givenComment, givenID);
        }
        public override void UpdateStatusToFalse()
        {
            this.Status = false;
        }
    }
}
