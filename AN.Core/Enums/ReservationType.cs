using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum ReservationType
    {
        /// <summary>
        /// Only show next available empty time period
        /// </summary>
        [Display(Name = "Sequentially", ResourceType = typeof(Global))]
        Sequentially = 0,

        /// <summary>
        /// Show all available empty time periods
        /// </summary>
        [Display(Name = "Selective", ResourceType = typeof(Global))]
        Selective = 1
    }
}
