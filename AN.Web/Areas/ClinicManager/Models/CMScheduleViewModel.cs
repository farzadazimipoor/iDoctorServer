using AN.Core.Resources.Global;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.ClinicManager.Models
{
    public class CMVocationViewModel
    {
        [Display(Name = "From", ResourceType = typeof(Global))]
        public string FromDate { get; set; } = DateTime.Now.ToShortDateString();
        [Display(Name = "To", ResourceType = typeof(Global))]
        public string ToDate { get; set; } = DateTime.Now.ToShortDateString();
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }
    }
}