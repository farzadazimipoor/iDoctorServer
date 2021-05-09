using AN.Core.Data;
using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository.Schedules
{
    public partial class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IRepository<UsualSchedulePlan> _usualScheduleRepository;
        public ScheduleService(IRepository<Schedule> scheduleRepository, IRepository<UsualSchedulePlan> usualScheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            _usualScheduleRepository = usualScheduleRepository;
        }


        #region manual schedule
        public IList<Schedule> GetAllSchedules()
        {
            return _scheduleRepository.Table.ToList();
        }


        public Schedule GetScheduleById(int id)
        {
            if (id == 0) return null;
            return _scheduleRepository.GetById(id);
        }


        public virtual void InsertSchedule(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException();

            _scheduleRepository.Insert(schedule);
        }



        public virtual Schedule GetScheduleForDate(int serviceSupplyId, DateTime date)
        {
            if (serviceSupplyId == 0 || date == null) return null;

            var query = from s in _scheduleRepository.Table
                        where
                               s.ServiceSupplyId == serviceSupplyId &&
                               s.Start_DateTime.Date == date.Date
                        select s;

            var result = query.FirstOrDefault();
            return result;
        }



        public virtual Schedule GetScheduleForPolyclinicInDate(int polyclinicId, DateTime date)
        {
            if (polyclinicId == 0 || date == null) return null;

            var query = from s in _scheduleRepository.Table
                        where
                               s.ServiceSupply.ShiftCenterId == polyclinicId &&
                               s.Start_DateTime.Date == date.Date
                        select s;

            return query.FirstOrDefault();
        }



        public virtual async Task<Schedule> GetSingleManualScheduleForServiceSupply(int serviceSupplyId, DateTime start, DateTime end)
        {
            if (serviceSupplyId == 0 || start == null || end == null)
                throw new ArgumentNullException();

            var query = await (from s in _scheduleRepository.Table
                               where
                                      s.ServiceSupplyId == serviceSupplyId &&
                                      s.Start_DateTime == start &&
                                      s.End_DateTime == end
                               select s).ToListAsync();

            var result = query.FirstOrDefault();
            return result;
        }


        public virtual Schedule GetSingleManualScheduleForServiceSupply(int serviceSupplyId, DateTime date, int polyclinicHealthServiceId)
        {
            if (serviceSupplyId == 0) return null;

            var query = (from s in _scheduleRepository.Table
                         where
                                s.ServiceSupplyId == serviceSupplyId && s.ShiftCenterServiceId == polyclinicHealthServiceId &&
                                s.Start_DateTime.Date == date.Date
                         select s).FirstOrDefault();

            return query;
        }



        public virtual async Task<IList<Schedule>> GetManualSchedulesForServiceSupplyInDateAsync(int serviceSupplyId, DateTime date)
        {
            if (serviceSupplyId == 0 || date == null)
                throw new ArgumentNullException();

            var query = await (from s in _scheduleRepository.Table
                               where s.ServiceSupplyId == serviceSupplyId &&
                               s.Start_DateTime.Date == date.Date
                               select s).ToListAsync();

            return query;
        }


        public virtual IList<Schedule> GetManualSchedulesForServiceSupplyInDate(int serviceSupplyId, DateTime date)
        {
            if (serviceSupplyId == 0 || date == null)
                throw new ArgumentNullException();

            var query = (from s in _scheduleRepository.Table
                         where s.ServiceSupplyId == serviceSupplyId && s.Start_DateTime.Date == date.Date
                         select s).ToList();

            return query;
        }

        public virtual void UpdateSchedule(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException("schedule");

            _scheduleRepository.Update(schedule);
        }

        public virtual void DeleteSchedule(Schedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException("schedule");

            _scheduleRepository.Delete(schedule);
        }
        #endregion


        #region usual schedule
        public virtual void UpdateUsualSchedule(UsualSchedulePlan schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException("schedule");

            _usualScheduleRepository.Update(schedule);
        }

        public virtual void DeleteUsualSchedule(UsualSchedulePlan schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException("schedule");

            _usualScheduleRepository.Delete(schedule);
        }


        public virtual UsualSchedulePlan GetUsualScheduleById(int id, int polyclinicId)
        {
            if (id == 0 || polyclinicId == 0)
                return null;

            return _usualScheduleRepository.Table.FirstOrDefault(us => us.ServiceSupply.ShiftCenterId == polyclinicId && us.Id == id);
        }


        public virtual IList<UsualSchedulePlan> GetUsualPlansForServiceSupplyInDayOfWeek(int polyclinicId, int serviceSupplyId, DayOfWeek dayOfWeek)
        {
            if (polyclinicId == 0 || serviceSupplyId == 0)
                return new List<UsualSchedulePlan>();

            var query = from u in _usualScheduleRepository.Table
                        where
                              u.ServiceSupply.ShiftCenterId == polyclinicId &&
                              u.DayOfWeek == dayOfWeek &&
                              u.ServiceSupplyId == serviceSupplyId
                        select u;

            return query.ToList();
        }

        public void InsertUsualSchedule(UsualSchedulePlan schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException("schedule");

            _usualScheduleRepository.Insert(schedule);
        }
        #endregion
    }
}
