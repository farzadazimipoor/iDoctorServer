using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PatientPersonInfoConfiguration : IEntityTypeConfiguration<PatientPersonInfo>
    {
        public void Configure(EntityTypeBuilder<PatientPersonInfo> builder)
        {
            builder.ToTable("PatientPersonInfo");

            builder.HasKey(p => p.PersonId);

            builder.Property(p => p.PersonId).IsRequired();

            builder.Property(p => p.FreeTurnsCount).IsRequired().HasDefaultValue(0);          

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
