using AN.Core.Attributes;
using AN.Core.Resources.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    [Flags]
    public enum ShiftCenterType
    {
        [CenterTypeOrder(Order = 0)]
        [CenterTypeIcon(Name = "polyclinic")]
        [DisplayName("polyclinic")]
        [Display(Name = "polyclinic", ResourceType = typeof(EnumResource))]
        Polyclinic = 1,

        [CenterTypeOrder(Order = 2)]
        [CenterTypeIcon(Name = "beautyCenter")]
        [DisplayName("beautyCenter")]
        [Display(Name = "beautyCenter", ResourceType = typeof(EnumResource))]
        BeautyCenter = 2,

        [CenterTypeOrder(Order = 1)]
        [CenterTypeIcon(Name = "dentist")]
        [DisplayName("dentist")]
        [Display(Name = "dentist", ResourceType = typeof(EnumResource))]
        Dentist = 4,

        [CenterTypeOrder(Order = 7)]
        [CenterTypeIcon(Name = "checkup")]
        [DisplayName("checkup")]
        [Display(Name = "checkup", ResourceType = typeof(EnumResource))]
        Checkup = 8,

        [CenterTypeOrder(Order = 4)]
        [CenterTypeIcon(Name = "healthyLifeStyle")]
        [DisplayName("healthyLifeStyle")]
        [Display(Name = "healthyLifeStyle", ResourceType = typeof(EnumResource))]
        HealthyLifeStyle = 16,

        [CenterTypeOrder(Order = 8)]
        [CenterTypeIcon(Name = "sonography")]
        [DisplayName("sonography")]
        [Display(Name = "sonography", ResourceType = typeof(EnumResource))]
        Sonography = 32,

        [CenterTypeOrder(Order = 9)]
        [CenterTypeIcon(Name = "CTScan")]
        [DisplayName("CTScan")]
        [Display(Name = "CTScan", ResourceType = typeof(EnumResource))]
        CTScan = 64,

        [CenterTypeOrder(Order = 10)]
        [CenterTypeIcon(Name = "MRI")]
        [DisplayName("MRI")]
        [Display(Name = "MRI", ResourceType = typeof(EnumResource))]
        MRI = 128,

        [CenterTypeOrder(Order = 11)]
        [CenterTypeIcon(Name = "radiology")]
        [DisplayName("radiology")]
        [Display(Name = "radiology", ResourceType = typeof(EnumResource))]
        Radiology = 256,

        [CenterTypeOrder(Order = 12)]
        [CenterTypeIcon(Name = "laboratory")]
        [DisplayName("laboratory")]
        [Display(Name = "laboratory", ResourceType = typeof(EnumResource))]
        Laboratory = 512,

        [CenterTypeOrder(Order = 13)]
        [CenterTypeIcon(Name = "pharmacy")]
        [DisplayName("pharmacy")]
        [Display(Name = "pharmacy", ResourceType = typeof(EnumResource))]
        Pharmacy = 1024,       

        [CenterTypeOrder(Order = 5)]
        [CenterTypeIcon(Name = "homecare")]
        [DisplayName("homecare")]
        [Display(Name = "homecare", ResourceType = typeof(EnumResource))]
        HomeCare = 2048,

        [CenterTypeOrder(Order = 14)]
        [CenterTypeIcon(Name = "covidcare")]
        [DisplayName("covidcare")]
        [Display(Name = "covidcare", ResourceType = typeof(EnumResource))]
        CovidCare = 4096,

        [CenterTypeOrder(Order = 15)]
        [CenterTypeIcon(Name = "ambulance")]
        [DisplayName("ambulance")]
        [Display(Name = "ambulance", ResourceType = typeof(EnumResource))]
        Ambulance = 8192        
    }
}
