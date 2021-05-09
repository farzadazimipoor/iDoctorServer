using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ScientificCategoryConfiguration : IEntityTypeConfiguration<ScientificCategory>
    {
        public void Configure(EntityTypeBuilder<ScientificCategory> builder)
        {
            builder.ToTable("ScientificCategory");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(50).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
