using System.Collections.Generic;

namespace AN.Core.DTO
{
    public class ScheduleInfoDTO
    {
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Service { get; set; }
        public int MaxCount { get; set; }
    }

    public class DayScheduleInfoDTO
    {
        public string DayOfWeek { get; set; }
        public List<ScheduleInfoDTO> Schedules { get; set; }
    }

    public class DoctorScheduleInfoDTO
    {
        public List<DayScheduleInfoDTO> Morning { get; set; }
        public List<DayScheduleInfoDTO> Evening { get; set; }        
    }
}
