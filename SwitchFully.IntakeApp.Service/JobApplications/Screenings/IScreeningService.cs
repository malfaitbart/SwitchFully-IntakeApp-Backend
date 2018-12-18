using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.JobApplications.Screenings
{
    public interface IScreeningService
    {
        Task<List<Screening>> GetAllScreeningsById(string id);
        Task<List<Screening>> NewScreening(string id, string comment);
    }
}
