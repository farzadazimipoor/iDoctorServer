using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class TreatmentHistoryConfiguration : IEntityTypeConfiguration<TreatmentHistory>
    {
        public void Configure(EntityTypeBuilder<TreatmentHistory> builder)
        {
            builder.ToTable("TreatmentHistory");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.VisitDate).IsRequired();

            builder.Property(p => p.Problems).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Problems_Ku).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Problems_Ar).IsUnicode().HasMaxLength(1000).IsRequired();

            builder.Property(p => p.Treatments).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Treatments_Ku).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Treatments_Ar).IsUnicode().HasMaxLength(1000).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(1000).IsRequired();          

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Patient).WithMany(p => p.TreatmentHistories).HasForeignKey(p => p.PatientId).IsRequired();          

            builder.HasOne(p => p.Appointment).WithMany(p => p.TreatmentHistories).HasForeignKey(p => p.AppointmentId).IsRequired(false);

            // One-TO-One
            builder.HasOne(p => p.PastMedicalHistory).WithOne(p => p.TreatmentHistory).HasForeignKey<PastMedicalHistory>(p => p.TreatmentHistoryId);
        }
    }
}
