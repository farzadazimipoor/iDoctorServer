using AN.Core.Resources.Global;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum PrescriptionStatus
    {
        [DisplayName("pending")]
        [Display(Name = "Pending", ResourceType = typeof(Global))]
        PENDING = 0,

        [DisplayName("done")]
        [Display(Name = "Done", ResourceType = typeof(Global))]
        DONE = 1,
    }
}
