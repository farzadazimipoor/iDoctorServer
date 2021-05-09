using AN.Core.Domain;
using AN.Core.Enums;
using System;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Schedules
{
    public interface IUsualScheduleService
    {
        Task<UsualSchedulePlan> GetUsualSchedulePlanAsync(int serviceSupplyId, DayOfWeek dayOfWeek, ScheduleShift shift);
    }
}
