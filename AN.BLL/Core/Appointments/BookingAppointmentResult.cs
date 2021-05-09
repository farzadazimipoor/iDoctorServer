namespace AN.BLL.Core.Appointments
{
    public class BookingAppointmentResult
    {
        public BookingAppointmentStatus Status { get; set; }
        public string Message { get; set; }
        public long AppointmentId { get; set; }
        public string TrackingCode { get; set; }
    }
}
