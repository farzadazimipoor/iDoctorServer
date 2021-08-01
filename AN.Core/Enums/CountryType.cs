using AN.Core.Resources.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum CountryType
    {
        [DisplayName("country_international")]
        [Display(Name = "country_international", ResourceType = typeof(EnumResource))]
        International,

        [DisplayName("country_domestic")]
        [Display(Name = "country_domestic", ResourceType = typeof(EnumResource))]
        Domestic
    }
}
