using AN.Core;
using AN.Core.Enums;
using System;

namespace AN.Web.Areas.ClinicManager.Models
{
    public class CMAppointmentsViewModel
    {
        public long Id { get; set; }
        public AppointmentStatus Status { get; set; }
        public ReservationChannel ReservationChannel { get; set; }
        public DateTime StartDateTime { get; set; }
        public string PatientName { get; set; }
        public string PatientNationaCode { get; set; }
        public string PatientMobile { get; set; }
        public string DoctorName { get; set; }
        public string HealthServiceName { get; set; }
        public int ServiceSupplyId { get; set; }
    }        


    public class ReservationAppointmentModel
    {
        public TimePeriodType Type { get; set; }
        public string Time { get; set; }
        public string PatientMobile { get; set; }
        public bool IsOutOfSchedule { get; set; }
    }
}