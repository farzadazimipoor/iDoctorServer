using System.Collections.Generic;

namespace AN.Core.Models.Reporting
{
    public class ClinicWorkingHoursReportModel
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public List<WorkingHoursModel> Rows { get; set; }
    }

    public class WorkingHoursModel
    {
        public string DoctorName { get; set; }
        public string DayOfWeek { get; set; }
        public string Date { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Shift { get; set; }
    }
}
