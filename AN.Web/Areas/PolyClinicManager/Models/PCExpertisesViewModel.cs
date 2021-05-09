using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AN.Web.Areas.PolyClinicManager.Models
{

    public class SetPCDoctorExpertisesViewModel
    {
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public List<SelectPCDoctorExpertisesViewModel> Expertises { get; set; }
    }


    public class SelectPCDoctorExpertisesViewModel
    {
        public bool Selected { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ExpertiseCategoryName { get; set; }

        public int ScientificCateoryId { get; set; }
        public IEnumerable<SelectListItem> ListScientificCategories { get; set; }

    }
}