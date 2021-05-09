using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ShiftCenterPersonsConfiguration : IEntityTypeConfiguration<ShiftCenterPersons>
    {
        public void Configure(EntityTypeBuilder<ShiftCenterPersons> builder)
        {
            builder.ToTable("ShiftCenterPersons");

            builder.HasKey(p => new
            {
                p.ShiftCenterId,
                p.PersonId
            });

            builder.Property(p => p.IsManager).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.TempGeneratedPassword).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ShiftCenter).WithMany(p => p.ShiftCenterUsers).HasForeignKey(p => p.ShiftCenterId);

            builder.HasOne(p => p.Person).WithMany(p => p.ShiftCenterPersons).HasForeignKey(p => p.PersonId);
        }       
    }
}
