using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Web.Areas.Admin.Models
{
    public class ScheduleViewModel
    {
    }


    public class VocationDayViewModel
    {
        public int Id { get; set; }              

        [Display(Name = "Date", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public string Date { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }
    }
}