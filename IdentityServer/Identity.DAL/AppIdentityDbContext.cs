using Identity.Core.Domain;
using Identity.DAL.DomainConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.DAL
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser,ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole,IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasOne(u => u.UserProfile).WithOne(p => p.User).HasForeignKey<UserProfile>(p => p.UserId);

            builder.ApplyConfiguration(new UserProfileConfiguration())             
                   .ApplyConfiguration(new ApplicationUserRoleConfiguration());              
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
