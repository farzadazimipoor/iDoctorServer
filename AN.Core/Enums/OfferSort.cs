using AN.Core.Resources.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum OfferSort
    {
        [DisplayName("booking")]
        [Display(Name = "booking", ResourceType = typeof(EnumResource))]
        Booking,

        [DisplayName("visits")]
        [Display(Name = "visits", ResourceType = typeof(EnumResource))]
        Visits,

        [DisplayName("price")]
        [Display(Name = "price", ResourceType = typeof(EnumResource))]
        Price
    }

    public enum SortDir
    {
        [DisplayName("ascending")]
        [Display(Name = "ascending", ResourceType = typeof(EnumResource))]
        ASC,

        [DisplayName("descending")]
        [Display(Name = "descending", ResourceType = typeof(EnumResource))]
        DESC
    }
}
