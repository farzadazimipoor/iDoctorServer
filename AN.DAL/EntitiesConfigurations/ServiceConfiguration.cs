using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(500).IsRequired();

            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(500).IsRequired();

            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(500).IsRequired();

            builder.Property(p => p.Price).HasColumnType("decimal(19,4)");

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.Time).HasMaxLength(5).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ServiceCategory).WithMany(p => p.Services).HasForeignKey(p => p.ServiceCategoryId).IsRequired();
        }
    }
}
