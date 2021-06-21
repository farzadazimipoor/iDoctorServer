using AN.Core.Resources.Enums;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum AppointmentProgressStatus
    {
        [Display(Name = "created", ResourceType = typeof(EnumResource))]
        CREATED = 0,

        [Display(Name = "processing", ResourceType = typeof(EnumResource))]
        PROCESSING = 1,

        [Display(Name = "on_the_way", ResourceType = typeof(EnumResource))]
        ON_THE_WAY = 2,

        [Display(Name = "completed", ResourceType = typeof(EnumResource))]
        COMPLETED = 3
    }
}
