using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Schedules
{
    public class UsualScheduleService : IUsualScheduleService
    {
        private readonly IRepository<UsualSchedulePlan> _usualSchedulePlanRepository;
        public UsualScheduleService(IRepository<UsualSchedulePlan> usualSchedulePlanRepository)
        {
            _usualSchedulePlanRepository = usualSchedulePlanRepository;
        }

        public async Task<UsualSchedulePlan> GetUsualSchedulePlanAsync(int serviceSupplyId, DayOfWeek dayOfWeek, ScheduleShift shift)
        {
            var query = await _usualSchedulePlanRepository.Table.FirstOrDefaultAsync(x =>
                x.ServiceSupplyId == serviceSupplyId && x.DayOfWeek == dayOfWeek && x.Shift == shift);

            return query;
        }
    }
}
