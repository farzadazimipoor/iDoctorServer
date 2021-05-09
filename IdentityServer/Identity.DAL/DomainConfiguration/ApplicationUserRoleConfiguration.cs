using Identity.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.DAL.DomainConfiguration
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable("AspNetUserRoles");

            builder.HasKey(p => new { p.UserId, p.RoleId });

            builder.Property(p => p.UserId).ValueGeneratedNever();

            builder.Property(p => p.RoleId).ValueGeneratedNever();

            builder.HasOne(p => p.User).WithMany(p => p.UserRoles).HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Role).WithMany(p => p.RoleUsers).HasForeignKey(p => p.RoleId);
        }
    }
}