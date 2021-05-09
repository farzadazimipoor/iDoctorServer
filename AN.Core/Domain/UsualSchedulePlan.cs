using AN.Core.Data;
using AN.Core.Enums;
using System;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class UsualSchedulePlan : BaseEntity
    {
        public UsualSchedulePlan()
        {
            UsualScheduleInsurances = new HashSet<UsualScheduleInsurances>();
        }

        public DayOfWeek DayOfWeek { get; set; }

        public ScheduleShift Shift { get; set; }
       
        public string StartTime { get; set; }
       
        public string EndTime { get; set; }

        public PrerequisiteType Prerequisite { get; set; }

        public int MaxCount { get; set; }

        public DateTime ValidFromDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public int ServiceSupplyId { get; set; }

        public int ShiftCenterServiceId { get; set; }     
       
        public virtual ServiceSupply ServiceSupply { get; set; }
        
        public virtual ShiftCenterService ShiftCenterService { get; set; }

        public virtual ICollection<UsualScheduleInsurances> UsualScheduleInsurances { get; set; }
    }
}
