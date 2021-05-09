using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class DrugGroupsConfiguration : IEntityTypeConfiguration<DrugGroups>
    {
        public void Configure(EntityTypeBuilder<DrugGroups> builder)
        {
            builder.ToTable("DrugGroups");

            builder.HasKey(p => new
            {
                p.PharmaceuticalGroupId,
                p.DrugId
            });

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.PharmaceuticalGroup).WithMany(p => p.DrugGroups).HasForeignKey(p => p.PharmaceuticalGroupId).IsRequired();

            builder.HasOne(p => p.Drug).WithMany(p => p.DrugGroups).HasForeignKey(p => p.DrugId).IsRequired();
        }
    }
}
