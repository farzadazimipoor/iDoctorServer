namespace AN.Core.Models
{
    public class WorkingHourModel
    {
        public string DayOfWeek { get; set; }
        public string Shift { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        /// <summary>
        /// Shift Center Service Name Like Visit, etc...
        /// </summary>
        public string Service { get; set; }
        public int MaxCount { get; set; }
    }
}
