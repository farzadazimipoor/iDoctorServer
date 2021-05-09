using AN.Core.Resources.Global;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum Gender
    {
        [DisplayName("male")]
        [Display(Name = "Male", ResourceType = typeof(Global))]
        Male = 0,

        [DisplayName("female")]
        [Display(Name = "FeMale", ResourceType = typeof(Global))]
        Female = 1
    }
}
