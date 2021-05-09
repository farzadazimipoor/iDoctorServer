using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Models;
using System;
using System.Collections.Generic;

namespace AN.BLL.Core.Services
{
    public interface IScheduleManager
    {
        void SetManualSchedule(ServiceSupply serviceSupply, ManualScheduleModel scheduleModel, out List<Appointment> pendingAppoints);

        void UpdateManualSchedule(ManualScheduleModel scheduleModel, out List<Appointment> pendingAppoints);

        void RemoveSchedule(int id, out List<Appointment> pendingAppoints);

        ScheduleShift getScheduleShift(DateTime start, DateTime end);

        int CalculateRemainedReservaableAppointsCount(DayOfWeek dayOfWeek, int shift, string from, string to, int serviceSupplyId, int medicalServiceId);

        void EnsureHasSchedule(ServiceSupply serviceSupply, int centerServiceId, DateTime start, DateTime end, bool passIfNoSchedules = false);
    }
}
