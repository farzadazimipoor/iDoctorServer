using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PastMedicalHistoryConfiguration : IEntityTypeConfiguration<PastMedicalHistory>
    {
        public void Configure(EntityTypeBuilder<PastMedicalHistory> builder)
        {
            builder.ToTable("PastMedicalHistory");

            builder.HasKey(p => p.TreatmentHistoryId);          

            builder.Property(p => p.PresentIllness).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.DifferentialDiagnosis).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.DrugHistory).IsUnicode().HasMaxLength(500).IsRequired(false);                
            builder.Property(p => p.ExaminationHistory).IsUnicode().HasMaxLength(500).IsRequired(false);           
            builder.Property(p => p.FamilyHistory).IsUnicode().HasMaxLength(500).IsRequired(false);           
            builder.Property(p => p.FinalDiagnosis).IsUnicode().HasMaxLength(500).IsRequired(false);           
            builder.Property(p => p.PastMedical).IsUnicode().HasMaxLength(500).IsRequired(false);           
            builder.Property(p => p.SignsAndSymptomsHistory).IsUnicode().HasMaxLength(500).IsRequired(false);           
            builder.Property(p => p.SocialHistory).IsUnicode().HasMaxLength(500).IsRequired(false);           
            builder.Property(p => p.SurgicalHistory).IsUnicode().HasMaxLength(500).IsRequired(false);           
            builder.Property(p => p.SystemicReview).IsUnicode().HasMaxLength(500).IsRequired(false);           

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
