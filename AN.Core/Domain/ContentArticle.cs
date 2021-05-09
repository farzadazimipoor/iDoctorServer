using AN.Core.Data;
using AN.Core.Enums;

namespace AN.Core.Domain
{
    public class ContentArticle : BaseEntity
    {      
        public string Title { get; set; }
        public string Title_Ku { get; set; }
        public string Title_Ar { get; set; }

        public string Summary { get; set; }
        public string Summary_Ku { get; set; }
        public string Summary_Ar { get; set; }

        public string Body { get; set; }
        public string Body_Ku { get; set; }
        public string Body_Ar { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public string ImageUrl_Ku { get; set; }

        public string ThumbnailUrl_Ku { get; set; }

        public string ImageUrl_Ar { get; set; }

        public string ThumbnailUrl_Ar { get; set; }

        public bool IsPublished { get; set; }

        public ArticleReaderType ReaderType { get; set; } = ArticleReaderType.NORMAL;

        public int ContentCategoryId { get; set; }

        public virtual ContentCategory ContentCategory { get; set; }
    }
}
