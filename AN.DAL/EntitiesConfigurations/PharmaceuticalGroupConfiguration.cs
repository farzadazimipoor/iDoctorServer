using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PharmaceuticalGroupConfiguration : IEntityTypeConfiguration<PharmaceuticalGroup>
    {
        public void Configure(EntityTypeBuilder<PharmaceuticalGroup> builder)
        {
            builder.ToTable(" PharmaceuticalGroup");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(255).IsRequired();

            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(255).IsRequired();

            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(255).IsRequired();           

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");            
        }
    }
}
