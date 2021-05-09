using AN.Core.Resources.Global;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{   
    public class InsuranceServiceCRUDViewModel
    {
        public int? Id { get; set; } = null;

        #region Title       
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title_Ku { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title_Ar { get; set; }
        #endregion

        #region Summary       
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Summary { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Summary_Ku { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Summary_Ar { get; set; }
        #endregion

        #region Description       
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description_Ku { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description_Ar { get; set; }
        #endregion       

        [Display(Name = "Insurance", ResourceType = typeof(Global))]
        public int InsuranceId { get; set; }

        public Microsoft.AspNetCore.Http.IFormFile Photo { get; set; }       
    }

    public class InsuranceServiceFilterViewModel
    {
        public int? InsuranceId { get; set; }

        public string FilterString { get; set; }
    }

    public class InsuranceServiceListItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title { get; set; }

        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Summary { get; set; }       

        [Display(Name = "CreateDate", ResourceType = typeof(Global))]
        public string CreateDate { get; set; }

        [Display(Name = "Insurance", ResourceType = typeof(Global))]
        public string Insurance { get; set; }

        public string PhotoUrl { get; set; }

        public string PhotoHtml { get; set; }

        public string ActionsHtml { get; set; }
    }   
}
