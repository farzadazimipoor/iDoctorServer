using AN.Core;
using AN.Core.Domain;
using AN.Core.DTO.Doctors;
using AN.Core.Enums;
using AN.Core.Models;
using System;
using System.Collections.Generic;

namespace AN.BLL.Core.Services
{
    public interface IDoctorServiceManager
    {
        IList<TimePeriodModel> Calculate_Bookable_TimePeriods(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService);

        IList<TimePeriodModel> Calculate_Bookable_TimePeriods(DateTime start, DateTime end, int duration);

        IEnumerable<Appointment> Get_All_Appointments(ServiceSupply serviceSupply, DateTime Date);

        IEnumerable<Appointment> Get_All_Appointments_By_Status(ServiceSupply serviceSupply, DateTime Date, AppointmentStatus status);

        IEnumerable<TimePeriodModel> Calculate_InProgressAppointments_TimePriods(ServiceSupply serviceSupply, DateTime Date);

        IEnumerable<TimePeriodModel> Calculate_All_TimePeriods(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService);

        IEnumerable<TimePeriodModel> CalculateAllTimePeriodsForOffer(Offer offer);

        IEnumerable<TimePeriodModel> Calculate_Empty_TimePeriods(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService);

        IEnumerable<TimePeriodModel> Calculate_Available_Empty_TimePeriods_By_Percent(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService);

        IEnumerable<TimePeriodModel> CalculateFinalBookableTimePeriods(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService);

        TimePeriodModel FindFirstEmptyTimePeriodInDate(ServiceSupply serviceSupply, DateTime Date, ShiftCenterService polyclinicHealthService);

        TimePeriodModel FindFirstEmptyTimePeriodFromNow(ServiceSupply serviceSupply, ShiftCenterService polyclinicHealthService);

        DoctorTimePeriods FindFirstDateEmptyTimePeriodsFromNow(ServiceSupply serviceSupply, ShiftCenterService polyclinicHealthService);

        TimePeriodModel Find_First_Empty_TimePeriod_From_DateTime(ServiceSupply serviceSupply, DateTime from, ShiftCenterService polyclinicHealthService);

        TimePeriodModel Find_First_Empty_TimePeriod_FromDateTime_ToDateTime(ServiceSupply serviceSupply, DateTime From_DateTime, DateTime To_DateTime, ShiftCenterService polyclinicHealthService);

        bool IsEmptyTimePeriod(ServiceSupply serviceSupply, TimePeriodModel timePriod, ShiftCenterService polyclinicHealthService);

        bool IsAvailableEmptyTimePeriod(int serviceSupplyId, DateTime StartDateTime, DateTime EndDateTime, ShiftCenterService polyclinicHealthService);

        PrerequisiteType getPrerequsite(DateTime datetime, ServiceSupply serviceSupply);
    }
}
