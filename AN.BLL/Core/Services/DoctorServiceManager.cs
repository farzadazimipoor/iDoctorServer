using AN.BLL.Core.Appointments.InProgress;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core;
using AN.Core.Domain;
using AN.Core.DTO.Doctors;
using AN.Core.Enums;
using AN.Core.Models;
using AN.Core.MyExceptions;
using AN.Core.Resources.EntitiesResources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AN.BLL.Core.Services
{
    public class DoctorServiceManager : IDoctorServiceManager
    {

        private readonly IServiceSupplyService _serviceSupplyService;
        private readonly IServiceSupplyManager _serviceSupplyManager;
        private readonly IIPAsManager _iPAsManager;
        public DoctorServiceManager(IServiceSupplyService serviceSupplyService, IServiceSupplyManager serviceSupplyManager, IIPAsManager iPAsManager)
        {
            _serviceSupplyService = serviceSupplyService;
            _serviceSupplyManager = serviceSupplyManager;
            _iPAsManager = iPAsManager;
        }


        /// <summary>
        /// این متد لیست همه بازه های زمانی که قابلیت رزرو دارند را برای یک ارایه در یک تاریخ محاسبه و بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ - روز</param>
        /// <returns>لیست بازه های زمانی دارای قابلیت رزرو</returns>
        public IList<TimePeriodModel> Calculate_Bookable_TimePeriods(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService)
        {
            var BookableTimes = new List<TimePeriodModel>();

            var nonBreakTimes = _serviceSupplyManager.Get_Non_Break_Times(serviceSupply, Date, polyclinicHealthService);

            if (nonBreakTimes != null && nonBreakTimes.Count() >= 1)
            {
                foreach (var item in nonBreakTimes)
                {
                    for (var dt = item.StartDateTime; dt <= item.EndDateTime; dt = dt.AddMinutes(item.Duration))
                    {
                        var tpEndTime = dt.AddMinutes(item.Duration);
                        if (tpEndTime <= item.EndDateTime)
                        {
                            BookableTimes.Add(new TimePeriodModel
                            {
                                StartDateTime = dt,
                                EndDateTime = tpEndTime,
                                Duration = item.Duration,
                                Type = TimePeriodType.Empty
                            });
                        }
                        else
                        {
                            var tpStartTime = tpEndTime.AddMinutes(-item.Duration);

                            if (tpStartTime > item.StartDateTime && tpStartTime < item.EndDateTime)
                            {
                                BookableTimes.Add(new TimePeriodModel
                                {
                                    StartDateTime = tpStartTime,
                                    EndDateTime = item.EndDateTime,
                                    Duration = item.Duration,
                                    Type = TimePeriodType.Empty
                                });
                            }
                        }
                    }
                }
                return BookableTimes.OrderBy(x => x.StartDateTime).ToList();
            }

            return null;
        }




        public IList<TimePeriodModel> Calculate_Bookable_TimePeriods(DateTime start, DateTime end, int duration)
        {
            var BookableTimes = new List<TimePeriodModel>();

            if (start == null || end == null || duration <= 0)
                return BookableTimes;

            for (var dt = start; dt <= end; dt = dt.AddMinutes(duration))
            {
                var tpEndTime = dt.AddMinutes(duration);
                if (tpEndTime <= end)
                {
                    BookableTimes.Add(new TimePeriodModel
                    {
                        StartDateTime = dt,
                        EndDateTime = tpEndTime,
                        Duration = duration,
                        Type = TimePeriodType.Empty
                    });
                }
                else
                {
                    var tpStartTime = tpEndTime.AddMinutes(-duration);

                    if (tpStartTime > start && tpStartTime < end)
                    {
                        BookableTimes.Add(new TimePeriodModel
                        {
                            StartDateTime = tpStartTime,
                            EndDateTime = end,
                            Duration = duration,
                            Type = TimePeriodType.Empty
                        });
                    }
                }
            }

            return BookableTimes.OrderBy(x => x.StartDateTime).ToList();
        }




        /// <summary>
        /// همه قرارهای ملاقات یک ارایه را برای یک تاریخ مشخص بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ (فقط روز) و ساعت لازم نیست</param>
        /// <returns>لیست همه قرار های ملاقات ثبت شده برای ارایه</returns>
        public IEnumerable<Appointment> Get_All_Appointments(ServiceSupply serviceSupply, DateTime Date)
        {
            return serviceSupply.Appointments
                                .Where(x => x.Start_DateTime.Date == Date.Date && !x.IsDeleted)
                                .OrderBy(x => x.Start_DateTime);
        }




        /// <summary>
        /// همه قرارهای ملاقات یک ارایه را برای یک تاریخ مشخص بر اساس نوع قرارملاقات بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ (فقط روز) و ساعت لازم نیست</param>
        /// <param name="status">نوع قرار ملاقاتی که می خواهیم</param>
        /// <returns></returns>
        public IEnumerable<Appointment> Get_All_Appointments_By_Status(ServiceSupply serviceSupply, DateTime Date, AppointmentStatus status)
        {
            return serviceSupply.Appointments
                                .Where(x => x.Start_DateTime.Date == Date.Date && x.Status == status && !x.IsDeleted)
                                .OrderBy(x => x.Start_DateTime);
        }


        /// <summary>
        /// همه بازه های زمانی با نوع قرار ملاقات را برای ارایه مورد نظر در تاریخ مشخص شده محاسبه می کند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ (فقط روز) ساعت لازم نیست</param>
        /// <returns>لیست بازه های زمانی با نوع قرار ملاقات</returns>
        public IEnumerable<TimePeriodModel> Calculate_PendingAppointment_TimePeriods(ServiceSupply serviceSupply, DateTime Date)
        {
            //همه قرارهای انجام نشده و منتظر انجام را بدست می آوریم
            var pendingAppointments =
                Get_All_Appointments_By_Status(serviceSupply, Date, AppointmentStatus.Pending)
                .Where(x => x.Start_DateTime >= DateTime.Now);

            var result = pendingAppointments.Select(item => new TimePeriodModel
            {
                StartDateTime = item.Start_DateTime,
                EndDateTime = item.End_DateTime,
                Type = TimePeriodType.Appointment,
                Duration = serviceSupply.Duration
            }).OrderBy(x => x.StartDateTime);

            return result;

        }




        /// <summary>
        /// لیست همه بازه های زمانی قفل شده و در حال رزرو را برای ارایه موردنظر را در تاریخ مشخص شده بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ - روز</param>
        /// <returns>لیست بازه های زمانی در حال رزرو</returns>
        public IEnumerable<TimePeriodModel> Calculate_InProgressAppointments_TimePriods(ServiceSupply serviceSupply, DateTime Date)
        {
            var InProgressAppointments = _iPAsManager.GetAll(serviceSupply, Date);

            var result = InProgressAppointments.Select(item => new TimePeriodModel
            {
                StartDateTime = item.StartDateTime,
                EndDateTime = item.EndDateTime,
                Type = TimePeriodType.InProgressAppointment,
                Duration = serviceSupply.Duration
            }).OrderBy(x => x.StartDateTime);

            return result;
        }




        /// <summary>
        /// لیست همه بازه های زمانی قابل رزرو و رزرو شده و یا در حال رزرو را بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ - روز</param>
        /// <returns></returns>
        public IEnumerable<TimePeriodModel> Calculate_All_TimePeriods(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService)
        {
            var BookableTimePeriods = Calculate_Bookable_TimePeriods(serviceSupply, Date, polyclinicHealthService);

            if (BookableTimePeriods != null && BookableTimePeriods.Count() >= 1)
            {
                // This is necessary
                BookableTimePeriods = BookableTimePeriods.ToList();

                var appointments = Get_All_Appointments(serviceSupply, Date).ToList();

                var inProgressAppointments = Calculate_InProgressAppointments_TimePriods(serviceSupply, Date).ToList();

                if ((appointments == null || appointments.Count <= 0) &&
                    (inProgressAppointments == null || inProgressAppointments.Count <= 0))
                    return BookableTimePeriods;

                if (appointments != null && appointments.Count >= 1)
                {
                    foreach (var pa in appointments)
                    {
                        foreach (var bookable in BookableTimePeriods)
                        {
                            if (bookable.StartDateTime == pa.Start_DateTime && bookable.Type != TimePeriodType.InProgressAppointment)
                            {
                                BookableTimePeriods.ElementAt(BookableTimePeriods.IndexOf(bookable)).Type = pa.OfferId == null ? TimePeriodType.Appointment : TimePeriodType.OfferAppointment;
                                break;
                            }
                        }
                    }
                }

                if (inProgressAppointments != null && inProgressAppointments.Count >= 1)
                {
                    foreach (var ipa in inProgressAppointments)
                    {
                        foreach (var bookable in BookableTimePeriods)
                        {
                            if (bookable.StartDateTime == ipa.StartDateTime && bookable.Type != TimePeriodType.Appointment)
                            {
                                BookableTimePeriods.ElementAt(BookableTimePeriods.IndexOf(bookable)).Type = TimePeriodType.InProgressAppointment;
                            }
                        }
                    }
                }

                return BookableTimePeriods.OrderBy(x => x.StartDateTime);
            }

            return null;
        }


        public IEnumerable<TimePeriodModel> CalculateAllTimePeriodsForOffer(Offer offer)
        {
            var allTimePeriods = Calculate_All_TimePeriods(offer.ServiceSupply, offer.StartDateTime.Value, offer.ShiftCenterService);

            if (allTimePeriods != null && allTimePeriods.Any())
            {
                // This is necessary
                var listAllTimePeriods = allTimePeriods.ToList();

                var emptyTimePeriodsForOffer = listAllTimePeriods.Where(x => x.Type == TimePeriodType.Empty &&
                                                                         x.StartDateTime >= offer.StartDateTime &&
                                                                         x.StartDateTime < offer.EndDateTime).OrderByDescending(x => x.StartDateTime).ToList();
                if (emptyTimePeriodsForOffer.Any())
                {
                    var offersReservedCount = listAllTimePeriods.Count(x => x.Type == TimePeriodType.OfferAppointment);

                    if (offersReservedCount <= offer.MaxCount)
                    {
                        var remained = offer.MaxCount - offersReservedCount;

                        foreach (var item in emptyTimePeriodsForOffer)
                        {
                            if (remained > 0)
                            {
                                var index = listAllTimePeriods.IndexOf(item);

                                listAllTimePeriods.ElementAt(index).Type = TimePeriodType.EmptyOffer;

                                remained -= 1;
                            }
                        }
                    }
                }

                return listAllTimePeriods.OrderBy(x => x.StartDateTime);
            }

            return allTimePeriods;
        }


        /// <summary>
        /// همه بازه های زمانی خالی مربوط به ارایه در تاریخ مشخص شده را بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ</param>
        /// <returns></returns>
        public IEnumerable<TimePeriodModel> Calculate_Empty_TimePeriods(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService)
        {
            return Calculate_All_TimePeriods(serviceSupply, Date, polyclinicHealthService).Where(x => x.Type == TimePeriodType.Empty);
        }




        /// <summary>
        /// همه بازه های زمانی در دسترس و قابل استفاده را بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ</param>
        /// <returns>لیست بازه های زمانی در دسترس و قابل استفاده</returns>
        public IEnumerable<TimePeriodModel> Calculate_Available_Empty_TimePeriods(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService)
        {
            return
                Calculate_Empty_TimePeriods(serviceSupply, Date, polyclinicHealthService)
                .Where(x => x.StartDateTime >= DateTime.Now);
        }





        /// <summary>
        /// محاسبه بازه های زمانی در دسترس و محدود کردن تعداد آنها بر اساس درصد رزرو آنلاین
        /// </summary>
        /// <param name="serviceSupply"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public IEnumerable<TimePeriodModel> Calculate_Available_Empty_TimePeriods_By_Percent(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService)
        {
            if (!serviceSupply.IsAvailable) return null;

            var finalPercentPeriods = new List<TimePeriodModel>();

            var allTimePeriods = Calculate_All_TimePeriods(serviceSupply, Date, polyclinicHealthService);
            if (allTimePeriods != null && allTimePeriods.Count() > 0)
            {
                if (serviceSupply.OnlineReservationPercent < 100)
                {
                    var schedules = _serviceSupplyManager.GetSchedulesByDate(serviceSupply, Date, polyclinicHealthService);
                    foreach (var schedule in schedules)
                    {
                        for (var dt = schedule.Start_DateTime; dt <= schedule.End_DateTime; dt = dt.AddHours(1))
                        {
                            var hourPeriods = allTimePeriods.Where(x => x.StartDateTime >= dt && x.EndDateTime <= dt.AddHours(1)).ToList();
                            if (hourPeriods != null && hourPeriods.Count >= 1)
                            {
                                var hourPeriodsByPercentCount = serviceSupply.OnlineReservationPercent * hourPeriods.Count / 100;
                                if (hourPeriodsByPercentCount > 0)
                                {
                                    for (var i = 0; i < hourPeriodsByPercentCount; i++)
                                    {
                                        finalPercentPeriods.Add(hourPeriods.ElementAt(i));
                                    }
                                }
                            }
                        }
                        return finalPercentPeriods.Where(x => x.Type == TimePeriodType.Empty && x.StartDateTime >= DateTime.Now).OrderBy(x => x.StartDateTime);
                    }
                }
                return allTimePeriods.Where(x => x.Type == TimePeriodType.Empty && x.StartDateTime >= DateTime.Now).OrderBy(x => x.StartDateTime);
            }
            return null;
        }




        public IEnumerable<TimePeriodModel> CalculateFinalBookableTimePeriods(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService)
        {
            var allTimePeriods = Calculate_All_TimePeriods(serviceSupply, Date, polyclinicHealthService);

            if (allTimePeriods != null && allTimePeriods.Count() > 0)
            {
                var finalBookables = allTimePeriods.Where(x => x.Type == TimePeriodType.InProgressAppointment && x.StartDateTime >= DateTime.Now).OrderBy(x => x.StartDateTime);

                return finalBookables;
            }

            return null;
        }




        /// <summary>
        /// در تاریخ موردنظر اولین بازه زمانی خالی را برای ارایه موردنظر بدست می آورد
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="Date">تاریخ</param>
        /// <returns></returns>
        public TimePeriodModel FindFirstEmptyTimePeriodInDate(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService)
        {
            var emptyPeriods = Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, Date, polyclinicHealthService);
            if (emptyPeriods != null && emptyPeriods.Count() > 0)
                return emptyPeriods.FirstOrDefault();

            return null;
        }




        /// <summary>
        /// از همین الان شروع می کند و اولین بازه زمانی خالی را برای ارایه پیدا می کند و بر می گرداند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <returns></returns>
        public TimePeriodModel FindFirstEmptyTimePeriodFromNow(ServiceSupply serviceSupply, ShiftCenterService polyclinicHealthService)
        {
            if (!serviceSupply.IsAvailable) return null;

            var startReservationDate = serviceSupply.StartReservationDate > DateTime.Now ? serviceSupply.StartReservationDate : DateTime.Now;
            var lastDay = startReservationDate.AddDays(serviceSupply.ShiftCenter.ActiveDaysAhead);
            for (var dt = startReservationDate.Date; dt <= lastDay.Date; dt = dt.AddDays(1))
            {
                //var schedules = GetSchedulesByDate(serviceSupply, dt, polyclinicHealthService);
                //if (schedules != null && schedules.Count > 0)
                //{
                //    foreach (var schedule in schedules)
                //    {
                var result = Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, dt, polyclinicHealthService);

                if (result != null && result.Count() > 0)
                {
                    return result.FirstOrDefault(x => x.StartDateTime >= DateTime.Now);
                }
                //}
                //}
            }

            return null;
        }


        public DoctorTimePeriods FindFirstDateEmptyTimePeriodsFromNow(ServiceSupply serviceSupply, ShiftCenterService polyclinicHealthService)
        {
            if (!serviceSupply.IsAvailable) return new DoctorTimePeriods { TimePeriods = new List<TimePeriodModel>(), HasOffers = false };

            var startReservationDate = serviceSupply.StartReservationDate > DateTime.Now ? serviceSupply.StartReservationDate : DateTime.Now;
            var lastDay = startReservationDate.AddDays(serviceSupply.ShiftCenter.ActiveDaysAhead);
            for (var dt = startReservationDate.Date; dt <= lastDay.Date; dt = dt.AddDays(1))
            {
                var result = Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, dt, polyclinicHealthService);

                if (result != null && result.Any())
                {
                    // TODO: We can check here if doctor has offer for this date or not
                    // Then get offer here and calculate all time periods include offers

                    var hasOffer = serviceSupply.Offers.Any(x => x.StartDateTime.Value.Date == dt.Date);

                    var turns = result.Where(x => x.StartDateTime >= DateTime.Now);

                    if (serviceSupply.ReservationType == ReservationType.Selective)
                    {
                        return new DoctorTimePeriods { TimePeriods = turns.ToList(), HasOffers = hasOffer };
                    }
                    else
                    {
                        return new DoctorTimePeriods { TimePeriods = turns.Take(1).ToList(), HasOffers = hasOffer };
                    }
                }
            }

            return new DoctorTimePeriods { TimePeriods = new List<TimePeriodModel>(), HasOffers = false };
        }




        /// <summary>
        /// از تاریخ و ساعت مشخص شده شروع می کند و اولین بازه زمانی خالی را برای ارایه موردنظر پیدا می کند
        /// </summary>
        /// <param name="serviceSupply">ارایه موردنظر</param>
        /// <param name="From_DateTime">تاریخ</param>
        /// <param name="StartTime">ساعت</param>
        /// <returns></returns>
        public TimePeriodModel Find_First_Empty_TimePeriod_From_DateTime(ServiceSupply serviceSupply, DateTime from, ShiftCenterService polyclinicHealthService)
        {
            if (!serviceSupply.IsAvailable) return null;

            var availableEmptyPeriodsByPercent = new List<TimePeriodModel>();

            var startReservationDate = serviceSupply.StartReservationDate > from ? serviceSupply.StartReservationDate : from;
            var lastDay = startReservationDate.AddDays(serviceSupply.ShiftCenter.ActiveDaysAhead);
            for (var dt = startReservationDate.Date; dt <= lastDay.Date; dt = dt.AddDays(1))
            {
                var schedules = _serviceSupplyManager.GetSchedulesByDate(serviceSupply, dt, polyclinicHealthService);
                if (schedules != null && schedules.Count > 0)
                {
                    foreach (var schedule in schedules)
                    {
                        var result = Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, schedule.Start_DateTime, polyclinicHealthService);

                        if (result != null && result.Count() > 0)
                        {
                            return result.FirstOrDefault(x => x.StartDateTime >= DateTime.Now);
                        }
                    }
                }
            }

            return null;
        }




        /// <summary>
        /// از یک تاریخ تا تاریخ دیگری اولین بازه زمانی خالی را برای ارایه پیدا می کند
        /// </summary>
        /// <param name="serviceSupply"></param>
        /// <param name="From_DateTime"></param>
        /// <param name="To_DateTime"></param>
        /// <returns></returns>
        public TimePeriodModel Find_First_Empty_TimePeriod_FromDateTime_ToDateTime(ServiceSupply serviceSupply, DateTime From_DateTime, DateTime To_DateTime, ShiftCenterService polyclinicHealthService)
        {
            var BRH = serviceSupply.ShiftCenter.BookingRestrictionHours;

            if (From_DateTime >= To_DateTime)
                throw new Exception(Messages.ValidEmptyTimePeriodNotFound);

            if (From_DateTime < DateTime.Now)
                throw new Exception(Messages.ValidEmptyTimePeriodNotFound);


            for (var dt = From_DateTime; dt <= To_DateTime || dt.ToShortDateString().Trim() == To_DateTime.ToShortDateString().Trim(); dt = dt.AddDays(1))
            {
                var schedules = _serviceSupplyManager.GetSchedulesByDate(serviceSupply, dt, polyclinicHealthService);
                foreach (var schedule in schedules)
                {
                    //اگر در روز مورد نظر وضعیت زمانبندی برابر در دسترس باشد
                    if (schedule != null && (schedule.Start_DateTime - DateTime.Now).TotalHours > BRH && schedule.IsAvailable)
                    {
                        var timePeriods = Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, dt, polyclinicHealthService).ToList();
                        foreach (var item in timePeriods)
                        {
                            if (item != null && (item.StartDateTime >= From_DateTime && item.EndDateTime <= To_DateTime))
                            {
                                return item;
                            }
                        }
                    }
                }
            }

            return null;
        }




        /// <summary>
        /// مشخص می کند که آیا بازه زمانی موردنظر برای ارایه خالی است یا نه؟
        /// </summary>
        /// <param name="serviceSupply">ارایه</param>
        /// <param name="datetime">تاریخ و زمان</param>
        /// <returns></returns>
        public bool IsEmptyTimePeriod(ServiceSupply serviceSupply, TimePeriodModel timePriod, ShiftCenterService polyclinicHealthService)
        {
            var founded = Calculate_Empty_TimePeriods(serviceSupply, timePriod.StartDateTime, polyclinicHealthService)
                          .Where(x => x.StartDateTime == timePriod.StartDateTime && x.EndDateTime == timePriod.EndDateTime).FirstOrDefault();

            if (founded == null)
                return false;

            return true;
        }




        public bool IsAvailableEmptyTimePeriod(int serviceSupplyId, DateTime StartDateTime, DateTime EndDateTime, ShiftCenterService polyclinicHealthService)
        {
            if (StartDateTime.ToShortDateString() != EndDateTime.ToShortDateString())
                return false;
            if (StartDateTime >= EndDateTime)
                return false;

            var serviceSupply = _serviceSupplyService.GetServiceSupplyById(serviceSupplyId);

            if (serviceSupply == null)
                throw new EntityNotFoundException();

            var founded = Calculate_Available_Empty_TimePeriods_By_Percent(serviceSupply, StartDateTime, polyclinicHealthService)
                          .Where(x => x.StartDateTime == StartDateTime &&
                                      x.EndDateTime == EndDateTime).FirstOrDefault();

            if (founded == null)
                return false;

            return true;

        }


        /// <summary>
        /// این متد مشخص میکند که آیا پزشکی که سرویس ارایه میدهد برای همه زمانبندی هایش پیش نیاز تعریف شده است یا نه؟
        /// </summary>
        /// <param name="serviceSupply">پزشکی که در مطبی سرویس ارایه می دهد</param>
        /// <returns></returns>
        public bool IsNeedPrerequsiteForAllTimes(ServiceSupply serviceSupply)
        {
            var haveUsuals = (from u in serviceSupply.UsualSchedulePlans
                              where u.Prerequisite != PrerequisiteType.WithoutPrerequisite
                              select u).Count() >= 1;

            var haveSchedules = (from s in serviceSupply.Schedules
                                 where s.IsAvailable && s.Prerequisite != null && s.Prerequisite != PrerequisiteType.WithoutPrerequisite
                                 select s).ToList().Count >= 1;

            return haveUsuals || haveSchedules;


        }


        /// <summary>
        /// بدست آوردن پیش نیاز پزشک برای یک تاریخی
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="serviceSupply"></param>
        /// <returns></returns>
        public PrerequisiteType getPrerequsite(DateTime datetime, ServiceSupply serviceSupply)
        {
            var prerequsite = PrerequisiteType.WithoutPrerequisite;

            var specialSchedule = serviceSupply.Schedules.FirstOrDefault(x => x.IsAvailable && x.Start_DateTime.ToShortDateString() == datetime.ToShortDateString());
            if (specialSchedule != null && specialSchedule.Prerequisite != null)
            {
                prerequsite = specialSchedule.Prerequisite;
            }
            else
            {
                var shift = 0; //Mornig
                if (datetime.Hour >= Defaults.EveningStart.Hour && datetime.Hour <= Defaults.EveningEnd.Hour)
                    shift = 1; //Evening

                var plan = serviceSupply.UsualSchedulePlans.FirstOrDefault(x => x.Shift == (ScheduleShift)shift && x.DayOfWeek == datetime.DayOfWeek);
                if (plan != null)
                {
                    prerequsite = plan.Prerequisite;
                }
            }

            return prerequsite;
        }




        private List<T> ShuffleList<T>(List<T> inputList, int numOfItems)
        {
            var randomList = new List<T>();
            var r = new Random();
            var randomIndex = 0;
            while (numOfItems > 0)
            {
                while (randomList.Contains(inputList[randomIndex]))
                {
                    randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                }
                randomList.Add(inputList[randomIndex]); //add it to the new, random list                
                numOfItems--;
            }

            return randomList;
        }




    }
}
