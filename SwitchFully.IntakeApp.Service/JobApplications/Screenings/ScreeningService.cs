using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Data.Repositories;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications.Screenings;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Service.JobApplications.Screenings
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _repository;

        public ScreeningService(IScreeningRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Screening>> GetAllScreeningsById(string givenId)
        {
            return await _repository.GetAllById(Guid.Parse(givenId));
        }


        public async Task<List<Screening>> NewScreening(string givenId, string givenComment)
        {

            var listOfScreenings = await GetAllScreeningsById(givenId);

            if (listOfScreenings.Count == 6)
            {
                return listOfScreenings;
            }

            else if (listOfScreenings.Count != 0)
            {
                Screening lastScreeing = GetLastSCreening(listOfScreenings);

                var newScreening = lastScreeing.CreateNextScreening(Guid.Parse(givenId), givenComment);
                if (newScreening == null)
                {
                    await _repository.FinalizeScreening(lastScreeing);
                    return listOfScreenings;
                }

                await _repository.AddNewScreeningToDatabase(newScreening);
                listOfScreenings.Add(newScreening);
            }
            else
            {
                var newScreening = new CV_Screening(givenComment, Guid.Parse(givenId));

                await _repository.AddNewScreeningToDatabase(newScreening);

                listOfScreenings.Add(newScreening);
            }

            return listOfScreenings;
        }

        private static Screening GetLastSCreening(List<Screening> listOfScreenings)
        {
            Screening lastScreeing = listOfScreenings.FirstOrDefault(screening => screening.Status == true);

            if (lastScreeing == null)
            { throw new NotImplementedException(); }

            return lastScreeing;
        }
    }
}
