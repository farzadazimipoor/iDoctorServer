using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.ToTable("IdentityUser");

            builder.HasKey(p => p.Id);            

            builder.Property(p => p.UserId).HasMaxLength(256).IsRequired();

            builder.Property(p => p.UserName).HasMaxLength(256).IsRequired();

            builder.Property(p => p.Email).HasMaxLength(256).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Person).WithMany(p => p.IdentityUsers).HasForeignKey(p => p.PersonId).IsRequired();           
        }
    }
}
