using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class HospitalPersonsConfiguration : IEntityTypeConfiguration<HospitalPersons>
    {
        public void Configure(EntityTypeBuilder<HospitalPersons> builder)
        {
            builder.ToTable("HospitalPersons");

            builder.HasKey(p => new
            {
                p.HospitalId,
                p.PersonId
            });

            builder.Property(p => p.IsManager).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.TempGeneratedPassword).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Hospital).WithMany(p => p.HospitalUsers).HasForeignKey(p => p.HospitalId);

            builder.HasOne(p => p.Person).WithMany(p => p.HospitalPersons).HasForeignKey(p => p.PersonId);
        }
    }
}
