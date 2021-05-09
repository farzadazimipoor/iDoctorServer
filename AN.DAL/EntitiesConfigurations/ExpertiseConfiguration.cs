using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ExpertiseConfiguration : IEntityTypeConfiguration<Expertise>
    {
        public void Configure(EntityTypeBuilder<Expertise> builder)
        {
            builder.ToTable("Expertise");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(100).IsRequired();
            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(100).IsRequired();
            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(100).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ExpertiseCategory).WithMany(p => p.Expertises).HasForeignKey(p => p.ExpertiseCategoryId).IsRequired();            
        }
    }
}
