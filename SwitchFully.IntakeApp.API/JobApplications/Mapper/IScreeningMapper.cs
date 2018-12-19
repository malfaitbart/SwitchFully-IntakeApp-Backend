using SwitchFully.IntakeApp.API.JobApplications.Dtos;
using SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess;
using System.Collections.Generic;

namespace SwitchFully.IntakeApp.API.JobApplications.Mapper
{
    public interface IScreeningMapper
    {
        ScreeningDTO_Return FromScreeningToScreeningDTOReturn(Screening screening);
        List<ScreeningDTO_Return> FromScreeningListToScreeningDTOReturnList(List<Screening> screeningList);
    }
}