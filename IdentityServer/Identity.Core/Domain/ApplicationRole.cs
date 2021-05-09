using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Identity.Core.Domain
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsSystemRole { get; set; }

        public virtual ICollection<ApplicationUserRole> RoleUsers { get; set; } = new List<ApplicationUserRole>();
    }
}
