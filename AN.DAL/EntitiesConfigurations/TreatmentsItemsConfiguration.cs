using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class TreatmentsItemsConfiguration : IEntityTypeConfiguration<TreatmentsItems>
    {
        public void Configure(EntityTypeBuilder<TreatmentsItems> builder)
        {
            builder.ToTable("TreatmentsItems");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CustomDrugName).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.CustomDrugName_Ku).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.CustomDrugName_Ar).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.Dosage).HasMaxLength(5).IsRequired(false);

            builder.Property(p => p.Frequency).HasMaxLength(150).IsRequired(false);

            builder.Property(p => p.Quantity).HasMaxLength(50).IsRequired(false);

            builder.Property(p => p.DateStarted).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);           

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Drug).WithMany(p => p.TreatmentsItems).HasForeignKey(p => p.DrugId).IsRequired(false);

            builder.HasOne(p => p.TreatmentHistory).WithMany(p => p.TreatmentsItems).HasForeignKey(p => p.TreatmentHistoryId).IsRequired();
        }
    }
}
