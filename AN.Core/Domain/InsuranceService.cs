using AN.Core.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace AN.Core.Domain
{
    public class InsuranceService : BaseEntity
    {
        public string Title { get; set; }
        public string Title_Ku { get; set; }
        public string Title_Ar { get; set; }

        public string Summary { get; set; }
        public string Summary_Ku { get; set; }
        public string Summary_Ar { get; set; }

        public string Description { get; set; }
        public string Description_Ku { get; set; }
        public string Description_Ar { get; set; }

        public bool HasAttachments { get; set; } = false;

        public string Photo { get; set; }

        [NotMapped]
        public string RealPhoto => !string.IsNullOrEmpty(Photo) ? Photo : "/images/logo.png";

        public string FullPhotoUrl(string hostAddress) => $"{hostAddress}{RealPhoto}";

        public int InsuranceId { get; set; }

        public virtual Insurance Insurance { get; set; }
    }
}
