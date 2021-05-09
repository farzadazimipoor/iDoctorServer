using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PharmacyDoneTreatmentsConfiguration : IEntityTypeConfiguration<PharmacyDoneTreatments>
    {
        public void Configure(EntityTypeBuilder<PharmacyDoneTreatments> builder)
        {
            builder.ToTable("PharmacyDoneTreatments");

            builder.HasKey(p => new { p.TreatmentId, p.PharmacyPrescriptionId });

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.PharmacyPrescription).WithMany(p => p.DoneTreatments).HasForeignKey(p => p.PharmacyPrescriptionId);
        }
    }
}
