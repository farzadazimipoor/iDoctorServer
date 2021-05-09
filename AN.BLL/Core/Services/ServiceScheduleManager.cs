using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Schedules;
using AN.Core;
using AN.Core.Exceptions;
using AN.Core.MyExceptions;
using AN.Core.Resources.EntitiesResources;
using AN.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using AN.Core.Domain;
using AN.Core.Models;
using AN.Core.Enums;

namespace AN.BLL.Core.Services
{
    public class ScheduleManager : IScheduleManager
    {
        private readonly BanobatDbContext _dbContext;
        private readonly IDoctorServiceManager _doctorServiceManager;
        private readonly IServiceSupplyManager _serviceSupplyManager;
        private readonly IScheduleService _scheduleService;
        private readonly IAppointmentService _appointmentService;
        public ScheduleManager(BanobatDbContext dbContext, IDoctorServiceManager doctorServiceManager, IServiceSupplyManager serviceSupplyManager, IScheduleService scheduleService, IAppointmentService appointmentService)
        {
            _dbContext = dbContext;
            _doctorServiceManager = doctorServiceManager;
            _serviceSupplyManager = serviceSupplyManager;
            _scheduleService = scheduleService;
            _appointmentService = appointmentService;
        }

        public void SetManualSchedule(ServiceSupply serviceSupply, ManualScheduleModel scheduleModel, out List<Appointment> pendingAppoints)
        {
            if (scheduleModel.StartDateTime == null || scheduleModel.EndDateTime == null)
                throw new Exception(Messages.PlsEnterStartEndDateTime);

            pendingAppoints = new List<Appointment>();

            if (!scheduleModel.IsAvailable && scheduleModel.AllDay)
            {
                var pendingList = _appointmentService.GetPendingAppointmentsForServiceSupplyInManualSchedule(serviceSupply.Id, scheduleModel.StartDateTime, scheduleModel.EndDateTime);
                pendingAppoints.AddRange(pendingList);
            }

            if (!pendingAppoints.Any())
            {
                if (scheduleModel.AllDay)
                {
                    var schedules = _scheduleService.GetManualSchedulesForServiceSupplyInDate(serviceSupply.Id, scheduleModel.StartDateTime);
                    if (schedules.Count <= 0)
                    {
                        if (!scheduleModel.IsAvailable)
                        {
                            _scheduleService.InsertSchedule(new Schedule
                            {
                                Start_DateTime = scheduleModel.StartDateTime,
                                End_DateTime = scheduleModel.EndDateTime,
                                IsAvailable = scheduleModel.IsAvailable,
                                DayOfWeek = scheduleModel.StartDateTime.DayOfWeek.ToString(),
                                ServiceSupplyId = serviceSupply.Id,
                                Description_Ku = scheduleModel.StartDateTime.DayOfWeek + scheduleModel.StartDateTime.ToShortDateString(),
                                CreatedAt = DateTime.Now,
                                ShiftCenterServiceId = 1
                            });
                        }
                    }
                    else
                    {
                        if (schedules.Count == 1)
                        {
                            var _schedule = schedules.FirstOrDefault();
                            if (_schedule.Start_DateTime.Hour == 06 && _schedule.End_DateTime.Hour == 23)
                            {
                                if (scheduleModel.IsAvailable)
                                    _scheduleService.DeleteSchedule(_schedule);
                            }
                            else
                            {
                                _schedule.IsAvailable = scheduleModel.IsAvailable;
                                _scheduleService.UpdateSchedule(_schedule);
                            }
                        }
                        else
                        {
                            foreach (var item in schedules)
                            {
                                item.IsAvailable = scheduleModel.IsAvailable;
                                _scheduleService.UpdateSchedule(item);
                            }
                        }
                    }
                }
                else
                {
                    var preSchedule = _scheduleService.GetSingleManualScheduleForServiceSupply(serviceSupply.Id, scheduleModel.StartDateTime, scheduleModel.HealthServiceId);

                    var isValidSchedule = IsValidScheduleTimes(out string message, scheduleModel.StartDateTime, scheduleModel.EndDateTime, serviceSupply, preSchedule);
                    if (!isValidSchedule) throw new AwroNoreException(message);

                    var schedule = new Schedule
                    {
                        Start_DateTime = scheduleModel.StartDateTime,
                        End_DateTime = scheduleModel.EndDateTime,
                        ShiftCenterServiceId = scheduleModel.HealthServiceId,
                        Prerequisite = scheduleModel.Prerequisite,
                        IsAvailable = scheduleModel.IsAvailable,
                        MaxCount = scheduleModel.MaxCount,
                        Shift = getScheduleShift(scheduleModel.StartDateTime, scheduleModel.EndDateTime),
                        DayOfWeek = scheduleModel.StartDateTime.DayOfWeek.ToString(),
                        ServiceSupplyId = serviceSupply.Id,
                        Description_Ku = scheduleModel.StartDateTime.DayOfWeek + scheduleModel.StartDateTime.ToShortDateString(),
                        CreatedAt = DateTime.Now
                    };

                    _scheduleService.InsertSchedule(schedule);
                }
            }
        }

        public void UpdateManualSchedule(ManualScheduleModel scheduleModel, out List<Appointment> pendingAppoints)
        {
            pendingAppoints = new List<Appointment>();

            var schedule = _scheduleService.GetScheduleById(scheduleModel.Id ?? 0);
            if (schedule == null) throw new EntityNotFoundException();

            if (scheduleModel.IsAvailable && !schedule.IsAvailable && schedule.Start_DateTime.ToShortTimeString() == "06:00" && schedule.End_DateTime.ToShortTimeString() == "23:59")
            {
                RemoveSchedule(schedule.Id, out List<Appointment> pendingList);
                pendingAppoints = pendingList;
            }
            else
            {
                schedule.IsAvailable = scheduleModel.IsAvailable;
                schedule.Start_DateTime = scheduleModel.StartDateTime;
                schedule.End_DateTime = scheduleModel.EndDateTime;
                schedule.ShiftCenterServiceId = scheduleModel.HealthServiceId;
                schedule.MaxCount = scheduleModel.MaxCount;
                schedule.Prerequisite = scheduleModel.Prerequisite;

                _scheduleService.UpdateSchedule(schedule);
            }
        }

        public void RemoveSchedule(int id, out List<Appointment> pendingAppoints)
        {
            pendingAppoints = new List<Appointment>();

            var schedule = _scheduleService.GetScheduleById(id);
            if (schedule == null) throw new EntityNotFoundException();

            _scheduleService.DeleteSchedule(schedule);
        }

        public ScheduleShift getScheduleShift(DateTime start, DateTime end)
        {
            if (start.Hour >= Defaults.MorningStart.Hour && start.Hour < Defaults.MorningEnd.Hour)
                return ScheduleShift.Morning;
            return ScheduleShift.Evening;
        }

        public int CalculateRemainedReservaableAppointsCount(DayOfWeek dayOfWeek, int shift, string from, string to, int serviceSupplyId, int medicalServiceId)
        {
            try
            {
                var serviceSupply = _dbContext.ServiceSupplies.Find(serviceSupplyId);

                var remainedCounts = 0;

                var plans = (from p in _dbContext.UsualSchedulePlans
                             where p.ServiceSupplyId == serviceSupplyId &&
                                   p.DayOfWeek == dayOfWeek &&
                                   p.Shift == (ScheduleShift)shift
                             select p).ToList();

                if (plans.Count > 0)
                {
                    var startTime = DateTime.Parse(plans.FirstOrDefault().StartTime);
                    var endTime = DateTime.Parse(plans.FirstOrDefault().EndTime);

                    var allAllowedAppoints = ((endTime - startTime).TotalMinutes / serviceSupply.Duration);
                    var reserved = 0;
                    foreach (var item in plans)
                    {
                        reserved += item.MaxCount;
                    }
                    remainedCounts = (int)allAllowedAppoints - reserved;
                }
                else
                {
                    var startTime = DateTime.Parse(from);
                    var endTime = DateTime.Parse(to);

                    remainedCounts = (int)(((endTime - startTime).TotalMinutes / serviceSupply.Duration));
                }

                return remainedCounts;
            }
            catch
            {
                throw;
            }
        }

        public void EnsureHasSchedule(ServiceSupply serviceSupply, int centerServiceId, DateTime start, DateTime end, bool passIfNoSchedules = false)
        {
            // Ensure doctor has schedule for requested date/time
            var schedule = serviceSupply.Schedules.Where(x => x.ShiftCenterServiceId == centerServiceId && x.Start_DateTime <= start && x.End_DateTime >= end).FirstOrDefault();
            if (schedule == null)
            {
                var hasSchedule = false;

                var turnShift = getScheduleShift(start, end);

                var generalSchedules = serviceSupply.UsualSchedulePlans.Where(x => x.ShiftCenterServiceId == centerServiceId && x.DayOfWeek == start.DayOfWeek && x.Shift == turnShift).ToList();

                if (generalSchedules.Any())
                {
                    foreach (var item in generalSchedules)
                    {
                        var scheduleStartTime = DateTime.Parse($"{start.ToShortDateString()} {item.StartTime}");
                        var scheduleEndTime = DateTime.Parse($"{start.ToShortDateString()} {item.EndTime}");
                        if (scheduleStartTime <= start && scheduleEndTime >= start)
                        {
                            hasSchedule = true;
                            break;
                        }
                    }
                    if (!hasSchedule) throw new AwroNoreException(Messages.WorkingScheduleNotFoundForThisTime);
                }
                else
                {
                    if (!passIfNoSchedules)
                    {
                        throw new AwroNoreException(Messages.WorkingScheduleNotFoundForThisTime);
                    }                    
                }
            }
        }

        private bool IsValidScheduleTimes(out string message,
                                         DateTime start,
                                         DateTime end,
                                         ServiceSupply serviceSupply,
                                         Schedule preSchedule = null)
        {
            message = string.Empty;
            var result = true;

            try
            {
                //اگر زمان شروع کوچکتر از زمان پایان نباشد
                if (start >= end)
                    throw new Exception(Messages.ScheduleStartMustSmallerThanEnd);

                //زمان شروع زمانبندی نباید کوچکتر از زمان حال حاضر باشد
                if (start < DateTime.Now)
                    throw new ScheduleForPastException(start.ToShortTimeString());

                //زمان شروع زمانبندی نباید در محدوده ساعات محدودیت رزرو نوبت باشد
                if ((start - DateTime.Now).TotalHours < serviceSupply.ShiftCenter.BookingRestrictionHours)
                {
                    throw new Exception(Messages.ScheduleStartNotValidForBHR);
                }

                if (start < serviceSupply.StartReservationDate)
                {
                    throw new Exception(Messages.ScheduleStartSmallerThanDoctorTurningStart);
                }

                if (_serviceSupplyManager.IsLocalVocationDay(start, serviceSupply)/* || _serviceSupplyManager.IsSystemVocationDay(start)*/)
                    throw new ScheduleForVocationDayException(start.ToShortDateString());

                if (preSchedule != null)
                {
                    if (start < preSchedule.Start_DateTime && (end > preSchedule.Start_DateTime && end < preSchedule.End_DateTime))
                        throw new Exception(Messages.ScheduleHasInterferesWithPreviews);
                    if ((start > preSchedule.Start_DateTime && start < preSchedule.End_DateTime) && end > preSchedule.End_DateTime)
                        throw new Exception(Messages.ScheduleHasInterferesWithPreviews);
                    if ((start > preSchedule.Start_DateTime && start < preSchedule.End_DateTime) && (end > preSchedule.Start_DateTime && end < preSchedule.End_DateTime))
                        throw new Exception(Messages.ScheduleHasInterferesWithPreviews);
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                result = false;
            }

            return result;
        }
    }
}
