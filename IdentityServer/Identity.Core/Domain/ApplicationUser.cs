using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string LastOTPCode { get; set; }

        public DateTime? LastOTPTime { get; set; }

        public bool IsSystemUser { get; set; } = false;

        public UserProfile UserProfile { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
    }
}
