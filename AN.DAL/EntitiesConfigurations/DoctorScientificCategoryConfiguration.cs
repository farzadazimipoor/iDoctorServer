using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class DoctorScientificCategoryConfiguration : IEntityTypeConfiguration<DoctorScientificCategory>
    {
        public void Configure(EntityTypeBuilder<DoctorScientificCategory> builder)
        {
            builder.ToTable("DoctorScientificCategory");

            builder.HasKey(k => new
            {
                k.ServiceSupplyId,
                k.ScientificCategoryId
            });

            builder.HasOne(p => p.ServiceSupplyInfo).WithMany(p => p.DoctorScientificCategories).HasForeignKey(p => p.ServiceSupplyId).IsRequired();

            builder.HasOne(p => p.ScientificCategory).WithMany(p => p.DoctorScientificCategories).HasForeignKey(p => p.ScientificCategoryId).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
