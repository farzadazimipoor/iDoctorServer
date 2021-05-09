using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Province");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(50).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Country).WithMany(p => p.Provinces).HasForeignKey(p => p.CountryId).IsRequired(false);
        }
    }
}
