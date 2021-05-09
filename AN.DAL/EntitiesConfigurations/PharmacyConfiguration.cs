using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PharmacyConfiguration : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
        {
            builder.ToTable("Pharmacy");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(50).IsRequired();           

            builder.Property(p => p.Address).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.Address_Ku).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.Address_Ar).IsUnicode().HasMaxLength(255).IsRequired(false);

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);
           
            builder.Property(p => p.Location).IsRequired(false);
           
            builder.Property(x => x._Images).HasColumnName("Images");           

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.City).WithMany(p => p.Pharmacies).HasForeignKey(p => p.CityId).IsRequired();
        }
    }
}
