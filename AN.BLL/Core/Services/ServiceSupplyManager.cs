using AN.BLL.Helpers;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AN.BLL.Core.Services
{
    public class ServiceSupplyManager : IServiceSupplyManager
    {
        /// <summary>
        /// این متد برای یک تاریخ مشخص همه بازه های زمانی که پزشک می تواند سرویس ارایه دهد را محاسبه می کند
        /// بازه های زمانی غیراستراحت را محاسبه می کند
        /// </summary>
        /// <param name="supply">ارایه</param>
        /// <param name="Date">تاریخ موردنظر</param>
        /// <returns>لیست بازه های زمانی با قابلیت ارایه سرویس</returns>
        public IEnumerable<TimePeriodModel> Get_Non_Break_Times(ServiceSupply supply, DateTime Date, ShiftCenterService polyclinicHealthService, bool applyLimits = true)
        {
            IList<Schedule> schedules;

            if (applyLimits)
                schedules = GetSchedulesByDate(supply, Date, polyclinicHealthService);
            else
                schedules = GetSchedulesByDateWithoutFilter(supply, Date, polyclinicHealthService);

            if (schedules != null && schedules.Count > 0)
            {
                var nonBreaks = new List<TimePeriodModel>();
                var _duration = supply.Duration;

                foreach (var item in schedules)
                {
                    if (item.MaxCount > 0)
                    {
                        var appointsForSchedule = supply.Appointments.Where(a => a.Start_DateTime >= item.Start_DateTime && a.End_DateTime <= item.End_DateTime && (a.ShiftCenterService == null || (polyclinicHealthService != null && a.ShiftCenterServiceId == polyclinicHealthService.Id)) && !a.IsDeleted);
                        if (appointsForSchedule.Count() > 0)
                        {
                            var firstAppoint = appointsForSchedule.FirstOrDefault();
                            _duration = (int)(firstAppoint.End_DateTime - firstAppoint.Start_DateTime).TotalMinutes;
                        }
                        else
                        {
                            var _maxCount = item.MaxCount;
                            var manualSchedulesForOtherHealthServices = (from ms in supply.Schedules
                                                                         where ms.Start_DateTime == item.Start_DateTime &&
                                                                              ms.End_DateTime == item.End_DateTime &&
                                                                              ms.ShiftCenterServiceId != item.ShiftCenterServiceId
                                                                         select ms).ToList();
                            if (manualSchedulesForOtherHealthServices.Count > 0)
                            {
                                foreach (var ms in manualSchedulesForOtherHealthServices)
                                {
                                    _maxCount += ms.MaxCount;
                                }
                            }
                            else
                            {
                                var shift = Utils.GetScheduleShift(item.Start_DateTime, item.End_DateTime);

                                var usualSchedulesForOtherHelathServices = (from us in supply.UsualSchedulePlans
                                                                            where us.Shift == shift &&
                                                                                  us.DayOfWeek == item.Start_DateTime.DayOfWeek &&
                                                                                  us.StartTime == item.Start_DateTime.ToShortTimeString() &&
                                                                                  us.EndTime == item.End_DateTime.ToShortTimeString() &&
                                                                                  us.ShiftCenterServiceId != item.ShiftCenterServiceId
                                                                            select us).ToList();

                                foreach (var us in usualSchedulesForOtherHelathServices)
                                {
                                    _maxCount += us.MaxCount;
                                }
                            }
                            _duration = (int)Math.Ceiling(((item.End_DateTime - item.Start_DateTime).TotalMinutes) / _maxCount);
                        }
                    }

                    nonBreaks.Add(new TimePeriodModel
                    {
                        StartDateTime = item.Start_DateTime,
                        EndDateTime = item.End_DateTime,
                        Duration = _duration,
                        Type = TimePeriodType.Empty
                    });
                }

                return nonBreaks.OrderBy(x => x.StartDateTime);
            }
            return null;
        }


        /// <summary>
        /// زمانبندی تاریخ مشخص شده را برای ارایه موردنظر بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ (فقط روز) و ساعت لازم نیست</param>
        /// <returns>زمان بندی تاریخ مشخص شده برای ارایه</returns>
        public IList<Schedule> GetSchedulesByDate(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyClinicHealthService)
        {
            var specialNotAvailables = serviceSupply.Schedules.Where(x => (!x.IsAvailable || x.Start_DateTime.Hour == 06) && x.Start_DateTime.Date == Date.Date).ToList();
            if (specialNotAvailables.Count > 0)
            {
                return null;
            }

            //بررسی می کنیم که آیا زمانبندی دستی  و منحصربفرد برای تاریخ موردنظر تعریف شده است یا نه؟            
            var specialSchedules = polyClinicHealthService == null ?
                 serviceSupply.Schedules.Where(x => x.Start_DateTime.Date == Date.Date && x.IsAvailable).ToList()
                 :
                 serviceSupply.Schedules.Where(x => x.Start_DateTime.Date == Date.Date && x.ShiftCenterServiceId == polyClinicHealthService.Id && x.IsAvailable).ToList();

            if (specialSchedules.Count > 0)
            {
                return FilterAndGetValidSchedules(serviceSupply, specialSchedules, polyClinicHealthService);
            }
            else
            {
                //باید مطمین شویم که تاریخ موردنظر جزو روزهای تعطیل نمی باشد
                //var isVocation = IsSystemVocationDay(Date) || serviceSupply.PoliClinic.PoliClinicVocationDays.Count(x => x.Date.Date == Date.Date) >= 1;

                if (/*IsSystemVocationDay(Date) ||*/ IsLocalVocationDay(Date, serviceSupply)) return null;

                var usualDayPlans = polyClinicHealthService != null ?
                    serviceSupply.UsualSchedulePlans.Where(x => x.DayOfWeek == Date.DayOfWeek && x.ShiftCenterServiceId == polyClinicHealthService.Id).ToList()
                    :
                    serviceSupply.UsualSchedulePlans.Where(x => x.DayOfWeek == Date.DayOfWeek).ToList();

                if (usualDayPlans.Count == 0) return null;

                var usualSchedules = new List<Schedule>();
                foreach (var plan in usualDayPlans)
                {
                    usualSchedules.Add(new Schedule
                    {
                        CreatedAt = DateTime.Now,
                        DayOfWeek = plan.DayOfWeek.ToString(),
                        Description_Ku = "",
                        IsAvailable = serviceSupply.IsAvailable,
                        MaxCount = plan.MaxCount,
                        Shift = plan.Shift,
                        ShiftCenterServiceId = plan.ShiftCenterServiceId,
                        ServiceSupply = serviceSupply,
                        ServiceSupplyId = serviceSupply.Id,
                        Start_DateTime = DateTime.Parse(Date.ToShortDateString() + " " + plan.StartTime),
                        End_DateTime = DateTime.Parse(Date.ToShortDateString() + " " + plan.EndTime)
                    });
                }

                return usualSchedules != null ? FilterAndGetValidSchedules(serviceSupply, usualSchedules, polyClinicHealthService) : null;
            }
        }


        public IList<Schedule> FilterAndGetValidSchedules(ServiceSupply serviceSupply, List<Schedule> schedules, ShiftCenterService healthService)
        {

            var validSchedules = new List<Schedule>();

            // Policlinic Booking Restriction Hours      
            var BRH = serviceSupply.ShiftCenter.BookingRestrictionHours;

            var startReservationDate = serviceSupply.StartReservationDate > DateTime.Now ? serviceSupply.StartReservationDate : DateTime.Now;
            var lastDay = startReservationDate.AddDays(serviceSupply.ShiftCenter.ActiveDaysAhead);

            var startPoint = serviceSupply.ReservationRangeStartPoint;
            var endPoint = serviceSupply.ReservationRangeEndPointDiffMinutes;
            var endPointPosition = serviceSupply.ReservationRangeEndPointPosition;

            foreach (var schedule in schedules)
            {
                if (schedule.Start_DateTime.Date < startReservationDate.Date || schedule.Start_DateTime.Date > lastDay.Date)
                {
                    continue;
                }
                //===========================================================
                //برای روز آخر میخواهیم که نوبت دهی از ساعت 8 به بعد شروع شود
                if (schedule.Start_DateTime.Date == lastDay.Date)
                {
                    var reservationStartTimeForLastDay = DateTime.Parse(DateTime.Now.ToShortDateString() + " 08:00:00");
                    if (DateTime.Now < reservationStartTimeForLastDay)
                        continue;
                }
                //===========================================================
                //محدوده ای برای نوبت دهی در نظر گرفته نشده است
                if (startPoint == null && endPoint == null)
                {
                    if ((schedule.Start_DateTime - DateTime.Now).TotalHours <= BRH) continue;
                }
                else
                {
                    //شروع نوبت دهی همزمان با شروع ویزیت
                    if (startPoint == 0)
                    {
                        if (DateTime.Now < schedule.Start_DateTime) continue;
                    }
                    //Diff Minutes before visit time
                    if (startPoint > 0)
                    {
                        if ((schedule.Start_DateTime - DateTime.Now).TotalMinutes > startPoint) continue;
                    }
                    //پایان نوبت دهی تا انتهای زمان ویزیت
                    if (endPoint == -1)
                    {
                        if (DateTime.Now > schedule.End_DateTime) continue;
                    }
                    //پایان نوبت دهی تا شروع زمان ویزیت
                    if (endPoint == 0)
                    {
                        if (DateTime.Now >= schedule.Start_DateTime) continue;
                    }
                    //پایان نوبت دهی مدتی قبل یا بعد از شروع ویزیت
                    if (endPoint > 0)
                    {
                        var endPointTime = DateTime.Now;
                        //پایان قبل از شروع ویزیت
                        if (endPointPosition == Position.BEFORE)
                        {
                            endPointTime = schedule.Start_DateTime.AddMinutes(-endPoint);
                        }
                        else if (endPointPosition == Position.AFTER)
                        {
                            endPointTime = schedule.Start_DateTime.AddMinutes(endPoint);
                        }

                        if (DateTime.Now > endPointTime) continue;
                    }
                }

                //Check remained free appoints for polyclinic health service
                var appints = healthService != null ?
                    (from a in serviceSupply.Appointments
                     where (a.ShiftCenterService == null || a.ShiftCenterServiceId == healthService.Id) &&
                      a.Start_DateTime.Date == schedule.Start_DateTime.Date &&
                      a.Start_DateTime >= schedule.Start_DateTime &&
                      a.End_DateTime <= schedule.End_DateTime &&
                      !a.IsDeleted
                     select a).ToList()
                    :
                     (from a in serviceSupply.Appointments
                      where a.Start_DateTime.Date == schedule.Start_DateTime.Date &&
                      a.Start_DateTime >= schedule.Start_DateTime &&
                      a.End_DateTime <= schedule.End_DateTime &&
                      !a.IsDeleted
                      select a).ToList();

                if (schedule.MaxCount - appints.Count <= 0) continue;

                validSchedules.Add(schedule);
            }

            return validSchedules.Count > 0 ? validSchedules : null;
        }



        public IList<Schedule> GetSchedulesByDateWithoutFilter(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyClinicHealthService)
        {
            //بررسی می کنیم که آیا زمانبندی دستی  و منحصربفرد برای تاریخ موردنظر تعریف شده است یا نه؟            
            var specialSchedules = serviceSupply.Schedules.Where(x => x.Start_DateTime.Date == Date.Date && x.ShiftCenterServiceId == polyClinicHealthService.Id && x.IsAvailable).ToList();

            if (specialSchedules.Count > 0)
            {
                return specialSchedules;
            }
            else
            {
                //باید مطمین شویم که تاریخ موردنظر جزو روزهای تعطیل نمی باشد
                //var isVocation = IsSystemVocationDay(Date) || serviceSupply.PoliClinic.PoliClinicVocationDays.Count(x => x.Date.Date == Date.Date) >= 1;

                if (/*IsSystemVocationDay(Date) ||*/ IsLocalVocationDay(Date, serviceSupply)) return null;

                var usualDayPlans = serviceSupply.UsualSchedulePlans.Where(x => x.DayOfWeek == Date.DayOfWeek && x.ShiftCenterServiceId == polyClinicHealthService.Id).ToList();

                if (usualDayPlans.Count == 0) return null;

                var usualSchedules = new List<Schedule>();
                foreach (var plan in usualDayPlans)
                {
                    usualSchedules.Add(new Schedule
                    {
                        CreatedAt = DateTime.Now,
                        DayOfWeek = plan.DayOfWeek.ToString(),
                        Description_Ku = "",
                        IsAvailable = serviceSupply.IsAvailable,
                        MaxCount = plan.MaxCount,
                        Shift = plan.Shift,
                        ShiftCenterServiceId = plan.ShiftCenterServiceId,
                        ServiceSupply = serviceSupply,
                        ServiceSupplyId = serviceSupply.Id,
                        Start_DateTime = DateTime.Parse(Date.ToShortDateString() + " " + plan.StartTime),
                        End_DateTime = DateTime.Parse(Date.ToShortDateString() + " " + plan.EndTime)
                    });
                }

                return usualSchedules;
            }
        }



        public bool HaveWorkingSchedules(ServiceSupply serviceSupply, DateTime Date, int shift)
        {
            var specialSchedules = new List<Schedule>();

            var specialNotAvailables = serviceSupply.Schedules.Where(x => x.Start_DateTime.Date == Date.Date &&
                                                                          !x.IsAvailable &&
                                                                          ((x.Start_DateTime.Hour == 06 && x.End_DateTime.Hour == 23) || (Utils.GetScheduleShift(x.Start_DateTime, x.End_DateTime) == (ScheduleShift)shift))
                                                                          ).ToList();
            if (specialNotAvailables.Count > 0)
            {
                return false;
            }

            switch (shift)
            {
                case 0: //Morning
                    specialSchedules = serviceSupply.Schedules.Where(x => x.Start_DateTime.Date == Date.Date && (Utils.GetScheduleShift(x.Start_DateTime, x.End_DateTime) == ScheduleShift.Morning) && x.IsAvailable).ToList();
                    break;
                case 1: //Evening
                    specialSchedules = serviceSupply.Schedules.Where(x => x.Start_DateTime.Date == Date.Date && (Utils.GetScheduleShift(x.Start_DateTime, x.End_DateTime) == ScheduleShift.Evening) && x.IsAvailable).ToList();
                    break;
            }

            if (specialSchedules.Count > 0)
            {
                return true;
            }
            else
            {
                //باید مطمین شویم که تاریخ موردنظر جزو روزهای تعطیل نمی باشد
                //var isVocation = IsSystemVocationDay(Date) || serviceSupply.PoliClinic.PoliClinicVocationDays.Count(x => x.Date.Date == Date.Date) >= 1;

                if (/*IsSystemVocationDay(Date) ||*/ IsLocalVocationDay(Date, serviceSupply)) return false;

                var usualDayPlan = serviceSupply.UsualSchedulePlans.FirstOrDefault(x => x.Shift == (ScheduleShift)shift && x.DayOfWeek == Date.DayOfWeek);

                if (usualDayPlan == null) return false;

                return true;
            }
        }



        /// <summary>
        /// Determine if a Date is vocation day or not
        /// </summary>
        /// <param name="date">specified date</param>
        /// <returns>true or false</returns>
        //public bool IsSystemVocationDay(DateTime date)
        //{
        //    //only we need date and not time
        //    //Linq to entities dont support .Date or .ToShortDateString()
        //    var _date = date.Date;
        //    using (var context = new BanobatDbContext())
        //    {
        //        return context.VocationDays.FirstOrDefault(x => x.Date == _date) != null;
        //    }
        //}


        public bool IsLocalVocationDay(DateTime date, ServiceSupply serviceSupply)
        {
            if (serviceSupply.ShiftCenter.IsIndependent)
            {
                if (serviceSupply.ShiftCenter.Vocations == null) return false;

                return serviceSupply.ShiftCenter.Vocations.Where(v => date.Date >= v.F.Date && date.Date <= v.T.Date).Count() > 0;

            }
            else if (serviceSupply.ShiftCenter.Clinic.IsIndependent)
            {
                var isPolyclinicVocation = false;
                var isClinicVocation = false;

                if (serviceSupply.ShiftCenter.Vocations != null)
                    isPolyclinicVocation = serviceSupply.ShiftCenter.Vocations.Where(v => date.Date >= v.F.Date && date.Date <= v.T.Date).Count() > 0;

                if (serviceSupply.ShiftCenter.Clinic.Vocations != null)
                    isClinicVocation = serviceSupply.ShiftCenter.Clinic.Vocations.Where(v => date.Date >= v.F.Date && date.Date <= v.T.Date).Count() > 0;

                return isPolyclinicVocation || isClinicVocation;
            }
            else
            {
                var isPolyclinicVocation = false;
                var isClinicVocation = false;

                if (serviceSupply.ShiftCenter.Vocations != null)
                    isPolyclinicVocation = serviceSupply.ShiftCenter.Vocations.Where(v => date.Date >= v.F.Date && date.Date <= v.T.Date).Count() > 0;

                if (serviceSupply.ShiftCenter.Clinic.Vocations != null)
                    isClinicVocation = serviceSupply.ShiftCenter.Clinic.Vocations.Where(v => date.Date >= v.F.Date && date.Date <= v.T.Date).Count() > 0;

                return isPolyclinicVocation || isClinicVocation;
            }
        }


        public IList<TimePeriodModel> CalculateBreakTimes(IEnumerable<Schedule> schedules)
        {
            schedules = schedules.OrderBy(x => x.Start_DateTime);
            var breaks = new List<TimePeriodModel>();

            for (var i = 0; i < schedules.Count() - 1; i++)
            {
                var breakStart = schedules.ElementAt(i).End_DateTime;
                var breakEnd = schedules.ElementAt(i + 1).Start_DateTime;
                breaks.Add(new TimePeriodModel
                {
                    StartDateTime = breakStart,
                    EndDateTime = breakEnd,
                    Type = TimePeriodType.Break
                });
            }
            return breaks.OrderBy(x => x.StartDateTime).ToList();
        }
    }
}
