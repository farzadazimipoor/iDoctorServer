using AN.Core.Resources.Global;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.ClinicManager.Models
{
    public class CMSecurityViewModel
    {
       
    }


    public class CMBlockMobileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Mobile", ResourceType = typeof(Global))]
        [MaxLength(10, ErrorMessageResourceName = "Err_MobileMax10Char", ErrorMessageResourceType = typeof(Global))]
        [MinLength(10, ErrorMessageResourceName = "Err_MobileMin10Char", ErrorMessageResourceType = typeof(Global))]
        public string Mobile { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "Polyclinic", ResourceType = typeof(Global))]
        public int PolyclinicId { get; set; }

        public IEnumerable<SelectListItem> Polyclinics { get; set; }
    }

    public class BlockedMobilesViewModel
    {
        public int Id { get; set; }

        public string Mobile { get; set; }

        public string Description { get; set; }

        public int PolyclinicId { get; set; }
    }
}