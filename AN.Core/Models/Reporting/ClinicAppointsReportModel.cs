using System.Collections.Generic;

namespace AN.Core.Models
{
    public class ClinicAppointsReportModel
    {
        public int ClinicId { get; set; }
        public int PolyclinicId { get; set; }
        public string ClinicName { get; set; }
        public string PolyclinicName { get; set; }
        public string DoctorName { get; set; }
        public string FromToDate { get; set; }        
        public List<ClinicReportModel> Rows { get; set; }
    }

    public class ClinicReportModel
    {
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string PatientName { get; set; }
        public string Mobile { get; set; }
    }


    public class ClinicReportAllModel
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public List<ReportAllRowModel> Rows { get; set; }
    }

    public class ReportAllRowModel
    {
        public string RowNumber { get; set; }
        public string PolyclinicName { get; set; }
        public string DoctorName { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string PatientName { get; set; }
        public string Mobile { get; set; }
        public string Date { get; set; }
    }
}
