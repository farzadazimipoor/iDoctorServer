using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.Admin.Models
{
    public class ListUnApprovedViewModel
    {
        public int PoliClinicId { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Global))]
        public string PoliClinicName { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string PoliClinicDescription { get; set; }

        [Display(Name = "Sender", ResourceType = typeof(Global))]
        public string Applicant { get; set; }

        public string ApplicantId { get; set; }
        [Display(Name = "Password", ResourceType = typeof(Global))]
        public string TempPassword { get; set; }
    }   
}
