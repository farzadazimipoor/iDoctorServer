using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class CenterPrescriptionConfiguration : IEntityTypeConfiguration<CenterPrescription>
    {
        public void Configure(EntityTypeBuilder<CenterPrescription> builder)
        {
            builder.ToTable("CenterPrescriptions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.TreatmentHistoryId).IsRequired();

            builder.Property(p => p.CenterId).IsRequired();

            builder.Property(p => p.Status).IsRequired();

            builder.Property(v => v._SonarNeedIds).HasColumnName("SonarNeedIds");

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.TreatmentHistory).WithMany(p => p.Prescriptions).HasForeignKey(p => p.TreatmentHistoryId);

            builder.HasOne(p => p.Center).WithMany(p => p.Prescriptions).HasForeignKey(p => p.CenterId);
        }
    }
}
