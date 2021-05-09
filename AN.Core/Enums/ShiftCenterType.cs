using AN.Core.Attributes;
using AN.Core.Resources.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    public enum ShiftCenterType
    {
        [CenterTypeOrder(Order = 0)]
        [CenterTypeIcon(Name = "polyclinic")]
        [DisplayName("polyclinic")]
        [Display(Name = "polyclinic", ResourceType = typeof(EnumResource))]
        Polyclinic = 0,

        [CenterTypeOrder(Order = 2)]
        [CenterTypeIcon(Name = "beautyCenter")]
        [DisplayName("beautyCenter")]
        [Display(Name = "beautyCenter", ResourceType = typeof(EnumResource))]
        BeautyCenter = 1,

        [CenterTypeOrder(Order = 1)]
        [CenterTypeIcon(Name = "dentist")]
        [DisplayName("dentist")]
        [Display(Name = "dentist", ResourceType = typeof(EnumResource))]
        Dentist = 2,

        [CenterTypeOrder(Order = 7)]
        [CenterTypeIcon(Name = "checkup")]
        [DisplayName("checkup")]
        [Display(Name = "checkup", ResourceType = typeof(EnumResource))]
        Checkup = 3,

        [CenterTypeOrder(Order = 4)]
        [CenterTypeIcon(Name = "healthyLifeStyle")]
        [DisplayName("healthyLifeStyle")]
        [Display(Name = "healthyLifeStyle", ResourceType = typeof(EnumResource))]
        HealthyLifeStyle = 4,

        [CenterTypeOrder(Order = 8)]
        [CenterTypeIcon(Name = "sonography")]
        [DisplayName("sonography")]
        [Display(Name = "sonography", ResourceType = typeof(EnumResource))]
        Sonography = 5,

        [CenterTypeOrder(Order = 9)]
        [CenterTypeIcon(Name = "CTScan")]
        [DisplayName("CTScan")]
        [Display(Name = "CTScan", ResourceType = typeof(EnumResource))]
        CTScan = 6,

        [CenterTypeOrder(Order = 10)]
        [CenterTypeIcon(Name = "MRI")]
        [DisplayName("MRI")]
        [Display(Name = "MRI", ResourceType = typeof(EnumResource))]
        MRI = 7,

        [CenterTypeOrder(Order = 11)]
        [CenterTypeIcon(Name = "radiology")]
        [DisplayName("radiology")]
        [Display(Name = "radiology", ResourceType = typeof(EnumResource))]
        Radiology = 8,

        [CenterTypeOrder(Order = 12)]
        [CenterTypeIcon(Name = "laboratory")]
        [DisplayName("laboratory")]
        [Display(Name = "laboratory", ResourceType = typeof(EnumResource))]
        Laboratory = 9,

        [CenterTypeOrder(Order = 13)]
        [CenterTypeIcon(Name = "pharmacy")]
        [DisplayName("pharmacy")]
        [Display(Name = "pharmacy", ResourceType = typeof(EnumResource))]
        Pharmacy = 10,

        [CenterTypeOrder(Order = 3)]
        [CenterTypeIcon(Name = "salon")]
        [DisplayName("salon")]
        [Display(Name = "salon", ResourceType = typeof(EnumResource))]
        Salon = 11,

        [CenterTypeOrder(Order = 14)]
        [CenterTypeIcon(Name = "nailSpa")]
        [DisplayName("nailSpa")]
        [Display(Name = "nailSpa", ResourceType = typeof(EnumResource))]
        NailSpa = 12,

        [CenterTypeOrder(Order = 6)]
        [CenterTypeIcon(Name = "berber")]
        [DisplayName("berber")]
        [Display(Name = "berber", ResourceType = typeof(EnumResource))]
        Barber = 13,

        [CenterTypeOrder(Order = 5)]
        [CenterTypeIcon(Name = "homecare")]
        [DisplayName("homecare")]
        [Display(Name = "homecare", ResourceType = typeof(EnumResource))]
        HomeCare = 14,

        [CenterTypeOrder(Order = 15)]
        [CenterTypeIcon(Name = "optometrist")]
        [DisplayName("optometrist")]
        [Display(Name = "optometrist", ResourceType = typeof(EnumResource))]       
        Optometrist = 15
    }
}
