using AN.Core.Domain;
using AN.Core.Models;
using System;
using System.Collections.Generic;

namespace AN.BLL.Core.Services
{
    public interface IServiceSupplyManager
    {
        IEnumerable<TimePeriodModel> Get_Non_Break_Times(ServiceSupply supply, DateTime Date, ShiftCenterService polyclinicHealthService, bool applyLimits = true);

        IList<Schedule> GetSchedulesByDate(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyClinicHealthService);

        IList<Schedule> FilterAndGetValidSchedules(ServiceSupply serviceSupply, List<Schedule> schedules, ShiftCenterService healthService);

        IList<Schedule> GetSchedulesByDateWithoutFilter(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyClinicHealthService);

        bool HaveWorkingSchedules(ServiceSupply serviceSupply, DateTime Date, int shift);

        //bool IsSystemVocationDay(DateTime date);

        bool IsLocalVocationDay(DateTime date, ServiceSupply serviceSupply);

        IList<TimePeriodModel> CalculateBreakTimes(IEnumerable<Schedule> schedules);

    }
}
