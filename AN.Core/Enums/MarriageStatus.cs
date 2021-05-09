using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum MarriageStatus
    {
        [Display(Name = "Single", ResourceType = typeof(Global))]
        Single = 0,

        [Display(Name = "Married", ResourceType = typeof(Global))]
        Married = 1
    }
}
