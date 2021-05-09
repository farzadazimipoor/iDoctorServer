using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum Language
    {
        [Display(Name = "Kurdish", ResourceType = typeof(Global))]
        Kurdish = 0,

        [Display(Name = "Arabic", ResourceType = typeof(Global))]
        Arabic = 1,

        [Display(Name = "Persian", ResourceType = typeof(Global))]
        Persian = 2,

        [Display(Name = "English", ResourceType = typeof(Global))]
        English = 3,
    }
}
