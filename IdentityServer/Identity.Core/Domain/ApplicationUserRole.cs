using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Domain
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public override string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public override string RoleId { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
