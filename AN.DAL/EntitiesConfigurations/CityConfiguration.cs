using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(50).IsRequired();           

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Province).WithMany(p => p.Cities).HasForeignKey(p => p.ProvinceId).IsRequired();

        }
    }
}
