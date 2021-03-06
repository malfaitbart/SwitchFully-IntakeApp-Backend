﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess
{
    public class Phone_Screening : Screening
    {
        private Phone_Screening()
        {

        }

        public Phone_Screening(string comment, Guid givenID) : base("Phone", givenID, comment, typeof(TestResults_Screening).ToString(), 2)
        {
        }

        public override Screening CreateNextScreening(Guid givenID, string givenComment)
        {
            UpdateStatusToFalse();
            return new TestResults_Screening(givenComment, givenID);
        }

        public override void UpdateStatusToFalse()
        {
            this.Status = false;
        }
    }
}
