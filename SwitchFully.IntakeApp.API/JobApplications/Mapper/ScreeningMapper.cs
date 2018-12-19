using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;

namespace SwitchFully.IntakeApp.API.JobApplications.Mapper
{
    public class ScreeningMapper : IScreeningMapper
    {
        public List<ScreeningDTO_Return> FromScreeningListToScreeningDTOReturnList(List<Screening> screeningList)
        {
            var newList = new List<ScreeningDTO_Return>();

            foreach (var screening in screeningList)
            {
                newList.Add(FromScreeningToScreeningDTOReturn(screening));
            }
            return newList;
        }

        public ScreeningDTO_Return FromScreeningToScreeningDTOReturn(Screening screening)
        {
            return new ScreeningDTO_Return
            {
                Name = screening.Name,
                NextScreeningType = screening.NextScreeningType,
                Comment = screening.Comment,
                Status = screening.Status,
                JobApplicationId = screening.JobApplicationId,
                AuditUser = screening.AuditUser,
                AuditDateTime = screening.AuditDateTime
            };
        }
    }
}
