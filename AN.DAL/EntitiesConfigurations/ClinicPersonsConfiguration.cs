using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ClinicPersonsConfiguration : IEntityTypeConfiguration<ClinicPersons>
    {
        public void Configure(EntityTypeBuilder<ClinicPersons> builder)
        {
            builder.ToTable("ClinicPersons");

            builder.HasKey(p => new
            {
                p.Clinic_Id,
                p.PersonId
            });

            builder.Property(p => p.IsManager).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.TempGeneratedPassword).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Clinic).WithMany(p => p.ClinicUsers).HasForeignKey(p => p.Clinic_Id);

            builder.HasOne(p => p.Person).WithMany(p => p.ClinicPersons).HasForeignKey(p => p.PersonId);
        }
    }
}
