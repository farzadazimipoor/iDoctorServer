using AN.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Models
{
    [NotMapped]
    public class ManualScheduleModel
    {        
        public int? Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }      
        public int HealthServiceId { get; set; }
        public PrerequisiteType Prerequisite { get; set; }
        public bool IsAvailable { get; set; }
        public int MaxCount { get; set; }

        public bool AllDay => StartDateTime.ToShortTimeString() == "06:00" && EndDateTime.ToShortTimeString() == "23:59";
    }
}
