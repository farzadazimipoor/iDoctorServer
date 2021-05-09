using AN.Core.Data;
using AN.Core.Enums;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class ContentCategory : BaseEntity
    {
        public ContentCategory()
        {
            Articles = new HashSet<ContentArticle>();
        }

        public string Title { get; set; }
        public string Title_Ku { get; set; }
        public string Title_Ar { get; set; }

        public ContentLayoutStyle LayoutStyle { get; set; } = ContentLayoutStyle.HORIZONTAL;

        public virtual ICollection<ContentArticle> Articles { get; set; }
    }
}
