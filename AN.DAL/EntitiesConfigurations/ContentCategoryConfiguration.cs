using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ContentCategoryConfiguration : IEntityTypeConfiguration<ContentCategory>
    {
        public void Configure(EntityTypeBuilder<ContentCategory> builder)
        {
            builder.ToTable("ContentCategory");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).HasMaxLength(50).IsUnicode().IsRequired();

            builder.Property(p => p.Title_Ar).HasMaxLength(50).IsUnicode().IsRequired();

            builder.Property(p => p.Title_Ku).HasMaxLength(50).IsUnicode().IsRequired();
            
            builder.Property(p => p.LayoutStyle).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");          
        }
    }
}
