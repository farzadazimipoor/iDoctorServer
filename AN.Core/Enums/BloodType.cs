using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum BloodType
    {
        [DisplayName("unknown")]
        Unknown,

        [DisplayName("o_positive")]
        [Display(Name = "O+")]
        OPositive,

        [DisplayName("a_positive")]
        [Display(Name = "A+")]
        APositive,

        [DisplayName("b_positive")]
        [Display(Name = "B+")]
        BPositive,

        [DisplayName("ab_positive")]
        [Display(Name = "AB+")]
        ABPositive,

        [DisplayName("ab_negative")]
        [Display(Name = "AB-")]
        ABNegative,

        [DisplayName("a_negative")]
        [Display(Name = "A-")]
        ANegative,

        [DisplayName("b_negative")]
        [Display(Name = "B-")]
        BNegative,

        [DisplayName("o_negative")]
        [Display(Name = "O-")]
        ONegative       
    }
}
