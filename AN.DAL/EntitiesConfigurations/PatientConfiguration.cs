using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CenterId).IsRequired(false);

            builder.Property(p => p.ServiceSupplyId).IsRequired(false);

            builder.Property(p => p.PersonId).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ShiftCenter).WithMany(p => p.Patients).HasForeignKey(p => p.CenterId);

            builder.HasOne(p => p.ServiceSupply).WithMany(p => p.Patients).HasForeignKey(p => p.ServiceSupplyId);

            builder.HasOne(p => p.Person).WithMany(p => p.Patients).HasForeignKey(p => p.PersonId);
        }
    }
}
