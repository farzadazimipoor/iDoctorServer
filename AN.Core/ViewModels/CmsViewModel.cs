using AN.Core.Enums;
using AN.Core.Resources.Global;
using System;
using System.ComponentModel.DataAnnotations;

namespace AN.Core.ViewModels
{
    #region Content Category
    public class CmsCategoryItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title { get; set; }

        [Display(Name = "CreateDate", ResourceType = typeof(Global))]
        public string CreateDate { get; set; }

        [Display(Name = "LayoutStyle", ResourceType = typeof(Global))]
        public string LayoutStyle { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class CmsCategoryFilterViewModel
    {
        public string FilterString { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public ContentLayoutStyle? LayoutStyle { get; set; }
    }

    public class CmsCategoryCreateUpdateViewModel
    {
        public int? Id { get; set; } = null;

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

        [Display(Name = "LayoutStyle", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public ContentLayoutStyle LayoutStyle { get; set; }
             
    }
    #endregion

    #region Content Article
    public class CmsArticleItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Global))]
        public string Title { get; set; }
      
        [Display(Name = "Summary", ResourceType = typeof(Global))]
        public string Summary { get; set; }

        [Display(Name = "IsPublished", ResourceType = typeof(Global))]
        public string IsPublished { get; set; }

        [Display(Name = "CreateDate", ResourceType = typeof(Global))]
        public string CreateDate { get; set; }

        [Display(Name = "Category", ResourceType = typeof(Global))]
        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public string ImageHtml { get; set; }

        public string ActionsHtml { get; set; }
    }

    public class CmsArticleFilterViewModel
    {
        public int? CategoryId { get; set; }

        public string FilterString { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string IsPublishedFilter { get; set; }

        public bool IsPublished { get; set; }
    }

    public class CmsArticleCreateUpdateViewModel
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

        #region Body       
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Body { get; set; }
        
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Body_Ku { get; set; }
       
        [Display(Name = "Description", ResourceType = typeof(Global))]
        public string Body_Ar { get; set; }
        #endregion

        [Display(Name = "IsPublished", ResourceType = typeof(Global))]
        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public bool IsPublished { get; set; }

        [Display(Name = "Category", ResourceType = typeof(Global))]
        public int ContentCategoryId { get; set; }
       
        public Microsoft.AspNetCore.Http.IFormFile Image { get; set; }

        public Microsoft.AspNetCore.Http.IFormFile Image_Ku { get; set; }

        public Microsoft.AspNetCore.Http.IFormFile Image_Ar { get; set; }

        [Required(ErrorMessageResourceType = typeof(Global), ErrorMessageResourceName = "Err_ThisFieldIsRequired")]
        public ArticleReaderType ReaderType { get; set; }

        [Display(Name = "SendNotification", ResourceType = typeof(Global))]
        public bool SendNotification { get; set; }
    }
    #endregion
}
