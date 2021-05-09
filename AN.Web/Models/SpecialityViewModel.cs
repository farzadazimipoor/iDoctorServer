using AN.Core.Resources.Global;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Models
{
    public class SpecialityViewModel
    {
        public int PolyclinicId { get; set; }

        public int expertiseId { get; set; }

        public int categoryId { get; set; }

        public int doctorId { get; set; }
       
        public IEnumerable<SelectListItem> Categories { get; set; }
       
        public IEnumerable<SelectListItem> Expertises { get; set; }
      
        [Display(Name = "Category", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Category { get; set; }

        [Display(Name = "Expertise", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Expertise { get; set; }     

        [Display(Name = "Doctor", ResourceType = typeof(Global))]
        public string DoctorName { get; set; }
    }

    public class SetScientificGradeViewModel
    {
        public int CenterId { get; set; }
        public int ServiceSupplyId { get; set; }
        public List<int> Grades { get; set; }
    }
}