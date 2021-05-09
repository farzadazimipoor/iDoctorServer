using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class DiseaseRecordsFormConfiguration : IEntityTypeConfiguration<DiseaseRecordsForm>
    {
        public void Configure(EntityTypeBuilder<DiseaseRecordsForm> builder)
        {
            builder.ToTable("DiseaseRecordsForm");

            builder.HasKey(p => p.PersonId);

            builder.Property(p => p.PersonId).IsRequired();

            builder.Property(p => p.Age).IsRequired().HasDefaultValue(0);

            builder.Property(p => p.HasLongTermDisease).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.LongTermDiseasesDescription).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.DrugsYouUsed).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.MedicalAllergies).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.DoYouSmoke).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.HadSurgery).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.SurgeriesDescription).IsUnicode().HasMaxLength(1000).IsRequired(false);            

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
