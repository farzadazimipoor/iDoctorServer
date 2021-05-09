using AN.Core.Data;

namespace AN.Core.Domain
{
    public class IdentityUser : BaseEntity
    {      
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
