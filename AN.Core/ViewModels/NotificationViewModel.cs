using AN.Core.Resources.Global;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    public class NotificationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title { get; set; }

        [Display(Name = "CreateDate", ResourceType = typeof(Global))]
        public string CreateDate { get; set; }

        [Display(Name = "ValidUntil", ResourceType = typeof(Global))]
        public string ValidUntil { get; set; }        

        public string ActionsHtml { get; set; }
    }

    public class NotificationFilterViewModel
    {
        public string FilterString { get; set; }    

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }

    public class NotificationCreateUpdateViewModel
    {
        public int? Id { get; set; } = null;

        #region FirstName
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title_Ku { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength50")]
        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title_Ar { get; set; }
        #endregion

        #region SecondName
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Text { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Text_Ku { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(255, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength255")]
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Text_Ar { get; set; }
        #endregion

        #region ThirdName
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description_Ku { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "MaxLength1000")]
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Description_Ar { get; set; }
        #endregion                     

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        [Display(Name = "ValidUntil", ResourceType = typeof(Global))]
        public string ValidUntil { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public Microsoft.AspNetCore.Http.IFormFile Image { get; set; }
    }
}
