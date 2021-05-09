using AN.Core;
using AN.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Schedules
{
    public partial interface IScheduleService
    {

        #region manualSchedule
        void InsertSchedule(Schedule schedule);

        void UpdateSchedule(Schedule schedule);

        void DeleteSchedule(Schedule schedule);

        Schedule GetScheduleById(int id);

        IList<Schedule> GetAllSchedules();

        Schedule GetScheduleForDate(int serviceSupplyId, DateTime date);

        Schedule GetScheduleForPolyclinicInDate(int polyclinicId, DateTime date);

        Task<Schedule> GetSingleManualScheduleForServiceSupply(int serviceSupplyId, DateTime start, DateTime end);

        Schedule GetSingleManualScheduleForServiceSupply(int serviceSupplyId, DateTime date, int polyclinicHealthServiceId);

        Task<IList<Schedule>> GetManualSchedulesForServiceSupplyInDateAsync(int serviceSupplyId, DateTime date);

        IList<Schedule> GetManualSchedulesForServiceSupplyInDate(int serviceSupplyId, DateTime date);

        #endregion



        #region usualSchedule
        void InsertUsualSchedule(UsualSchedulePlan schedule);
        UsualSchedulePlan GetUsualScheduleById(int id, int polyclinicId);

        void UpdateUsualSchedule(UsualSchedulePlan schedule);

        void DeleteUsualSchedule(UsualSchedulePlan schedule);

        IList<UsualSchedulePlan> GetUsualPlansForServiceSupplyInDayOfWeek(int polyclinicId, int serviceSupplyId, DayOfWeek dayOfWeek);
        #endregion

    }
}
