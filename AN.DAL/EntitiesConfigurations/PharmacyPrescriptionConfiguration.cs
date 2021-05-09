using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PharmacyPrescriptionConfiguration : IEntityTypeConfiguration<PharmacyPrescription>
    {
        public void Configure(EntityTypeBuilder<PharmacyPrescription> builder)
        {
            builder.ToTable("PharmacyPrescriptions");

            builder.HasKey(p => p.Id);           

            builder.Property(p => p.TreatmentHistoryId).IsRequired();

            builder.Property(p => p.PharmacyId).IsRequired();

            builder.Property(p => p.Status).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.TreatmentHistory).WithMany(p => p.PharmacyPrescriptions).HasForeignKey(p => p.TreatmentHistoryId);

            builder.HasOne(p => p.Pharmacy).WithMany(p => p.Prescriptions).HasForeignKey(p => p.PharmacyId);
        }
    }
}
