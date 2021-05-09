using AN.Core;
using AN.Core.Enums;
using System;

namespace AN.Web.Areas.Admin.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public int ServiceSupplyId { get; set; }
        public AppointmentStatus Status { get; set; }
        public ReservationChannel ReservationChannel { get; set; }
        public DateTime DateTime { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string PatientMobile { get; set; }
    }
}