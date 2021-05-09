using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.Enums
{
    /// <summary>
    /// Doctor's Prerequisite for reserve appointment
    /// </summary>
    public enum PrerequisiteType
    {
        [Display(Name = "WithoutPrerequisite", ResourceType = typeof(Global))]
        WithoutPrerequisite = 0,

        [Display(Name = "WithIntroductionLetter", ResourceType = typeof(Global))]
        WithIntroductionLetter = 1
    }
}
