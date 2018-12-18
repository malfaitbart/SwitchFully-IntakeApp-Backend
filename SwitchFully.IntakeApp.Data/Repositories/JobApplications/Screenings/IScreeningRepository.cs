using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories.JobApplications.Screenings
{
    public interface IScreeningRepository
    {
        Task<List<Screening>> GetAllById(Guid id);
        Task<Screening> AddNewScreeningToDatabase(Screening newScreening);
        Task<Screening> FinalizeScreening(Screening lastScreeing);
    }
}
