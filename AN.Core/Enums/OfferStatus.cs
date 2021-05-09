using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum OfferStatus
    {
        [DisplayName("pending")]
        [Display(Name = "pending")]
        PENDING = 0,

        [DisplayName("approved")]
        [Display(Name = "approved")]
        APPROVED = 1,

        [DisplayName("rejected")]
        [Display(Name = "rejected")]
        REJECTED = 2
    }
}
