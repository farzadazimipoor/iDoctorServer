using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code).IsUnicode().HasMaxLength(50).IsRequired(false);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(50).IsRequired();

            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(50).IsRequired();

            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(50).IsRequired();

            builder.Property(p => p.HomeCareDescription).IsUnicode().IsRequired(false);

            builder.Property(p => p.HomeCareDescription_Ku).IsUnicode().IsRequired(false);

            builder.Property(p => p.HomeCareDescription_Ar).IsUnicode().IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}

