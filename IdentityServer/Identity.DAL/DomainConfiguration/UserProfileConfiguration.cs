using Identity.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.DAL.DomainConfiguration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfile");

            builder.HasKey(p => new { p.UserId });

            builder.Property(p => p.UserId).IsRequired();

            builder.Property(p => p.PersonId).IsRequired(false);

            builder.Property(p => p.CenterId).IsRequired(false);

            builder.Property(p => p.LoginAs).IsRequired();

            builder.Property(x => x._ServiceSupplyIds).HasColumnName("ServiceSupplyIds");

            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()").HasColumnType("datetime");

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
