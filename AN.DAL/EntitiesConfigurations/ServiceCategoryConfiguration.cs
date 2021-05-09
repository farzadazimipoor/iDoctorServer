using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.ToTable("ServiceCategory");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(100).IsRequired();
            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(100).IsRequired();
            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(100).IsRequired();

            builder.Property(p => p.CenterType).IsRequired();

            builder.Property(p => p.Photo).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
