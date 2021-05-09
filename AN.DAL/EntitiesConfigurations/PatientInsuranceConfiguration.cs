using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PatientInsuranceConfiguration : IEntityTypeConfiguration<PatientInsurance>
    {
        public void Configure(EntityTypeBuilder<PatientInsurance> builder)
        {
            builder.ToTable("PatientInsurance");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Insurance).WithMany(p => p.Patients).HasForeignKey(p => p.ServiceSupplyInsuranceId).IsRequired();

            builder.HasOne(p => p.UserPatientInfo).WithMany(p => p.PatientInsurances).HasForeignKey(p => p.UserPatientId).IsRequired();
        }
    }
}
