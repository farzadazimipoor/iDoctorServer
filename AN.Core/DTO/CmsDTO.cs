using AN.Core.Enums;
using System.Collections.Generic;

namespace AN.Core.DTO
{
    public class CmsCategoryDTO : BaseDTO
    {
        public string Title { get; set; }
        public int LayoutStyle { get; set; }
        public List<CmsArticleDTO> Articles { get; set; }
    }

    public class CmsArticleDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }       
        public string ThumbnailUrl { get; set; }
        public int CategoryId { get; set; }
        public ArticleReaderType ReaderType { get; set; }
    }

    public class CmsCategoriesResultDTO
    {
        public bool ShowDashboardAction { get; set; }
        public string DashboardActionTitle { get; set; }
        public string DashboardActionUrl { get; set; }
        public List<CmsCategoryDTO> CmsCategories { get; set; }
    }

    public class CmsArticleDetailsDTO : CmsArticleDTO
    {
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }
        public string CreatedAt { get; set; }
    }

    public class CmsArticlesListResultDTO
    {
        public int TotalCount { get; set; }
        public List<CmsArticleDTO> CmsArticles { get; set; }
    }
}
