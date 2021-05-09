using System.ComponentModel.DataAnnotations;

namespace Identity.Core.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            TenantId = string.Empty;
            IsDeleted = false;
        }

        [MaxLength(450)]
        public string TenantId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
