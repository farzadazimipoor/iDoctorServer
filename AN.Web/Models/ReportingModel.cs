namespace AN.Web.Models
{
    public class ClinicAppointmentsReportModel
    {
        public string ClinicName { get; set; }
        public string PolyclinicName { get; set; }
        public string DoctorName { get; set; }
        public string FromToDate { get; set; }
        //Rows........................
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string PatientName { get; set; }
        public string Mobile { get; set; }
    }
}