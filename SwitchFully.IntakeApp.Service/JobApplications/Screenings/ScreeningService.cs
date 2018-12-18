﻿using Microsoft.EntityFrameworkCore;
using SwitchFully.IntakeApp.Data.Repositories;
using SwitchFully.IntakeApp.Data.Repositories.JobApplications.Screenings;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using SwitchFully.IntakeApp.Service.Logging;
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
        private readonly ILoggerManager _loggerManager;

        
        public ScreeningService(IScreeningRepository repository, ILoggerManager loggerManager)
        {
            _repository = repository;
            _loggerManager = loggerManager;
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
                Screening lastScreening = GetLastSCreening(listOfScreenings);

                var newScreening = lastScreening.CreateNextScreening(Guid.Parse(givenId), givenComment);
                if (newScreening == null)
                {
                    await _repository.FinalizeScreening(lastScreening);
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
            Screening lastScreening = listOfScreenings.FirstOrDefault(screening => screening.Status == true);

            if (lastScreening == null)
            { throw new NotImplementedException(); }

            return lastScreening;
        }
    }
}
