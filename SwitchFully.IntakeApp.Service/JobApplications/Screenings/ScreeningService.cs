using SwitchFully.IntakeApp.Data.Repositories.JobApplications.Screenings;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using SwitchFully.IntakeApp.Service.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.JobApplications.Screenings
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _repository;
        private readonly IJobApplicationService _jobApplicationService;
        private readonly ILoggerManager _loggerManager;


        public ScreeningService(IScreeningRepository repository, ILoggerManager loggerManager, IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
            _repository = repository;
            _loggerManager = loggerManager;
        }

        public async Task<List<Screening>> GetAllScreeningsById(string givenId)
        {
            return await _repository.GetAllById(Guid.Parse(givenId));
        }

        public async Task<string> GetActiveScreeningStepForJobApplicationId(Guid id)
        {
            return await _repository.GetActiveScreeningStepForJobApplicationId(id);
        }

        public async Task<List<Screening>> NewScreening(string givenId, string givenComment)
        {

            var listOfScreenings = await GetAllScreeningsById(givenId);

            if (listOfScreenings.Count == 6)
            { return listOfScreenings; }
            else if (listOfScreenings.Count != 0)
            {
                Screening lastScreening = listOfScreenings.FirstOrDefault(screening => screening.Status == true);

                if (lastScreening == null)
                { return null; }

                var newScreening = lastScreening.CreateNextScreening(Guid.Parse(givenId), givenComment);

                await FinalizeJobApplicationOnLastScreeningStep(givenId, newScreening);
                await SaveScreeningToRepo(listOfScreenings, newScreening);
            }
            else
            {
                var newScreening = new CV_Screening(givenComment, Guid.Parse(givenId));
                await SaveScreeningToRepo(listOfScreenings, newScreening);
            }

            return listOfScreenings;
        }


        private async Task FinalizeJobApplicationOnLastScreeningStep(string givenId, Screening newScreening)
        {
            if (newScreening.GetType() == typeof(FinalDecision_Screening))
            { await _jobApplicationService.UpdateStatusOfJobApplication(givenId, 4); }
        }

        private async Task SaveScreeningToRepo(List<Screening> listOfScreenings, Screening newScreening)
        {
            await _repository.AddNewScreeningToDatabase(newScreening);
            listOfScreenings.Add(newScreening);
        }
    }
}
