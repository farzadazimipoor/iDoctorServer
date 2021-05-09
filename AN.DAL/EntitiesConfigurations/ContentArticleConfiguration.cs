using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ContentArticleConfiguration : IEntityTypeConfiguration<ContentArticle>
    {
        public void Configure(EntityTypeBuilder<ContentArticle> builder)
        {
            builder.ToTable("ContentArticle");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).HasMaxLength(50).IsUnicode().IsRequired(false);

            builder.Property(p => p.Title_Ar).HasMaxLength(50).IsUnicode().IsRequired(false);

            builder.Property(p => p.Title_Ku).HasMaxLength(50).IsUnicode().IsRequired(false);

            builder.Property(p => p.Summary).HasMaxLength(255).IsUnicode().IsRequired(false);

            builder.Property(p => p.Summary_Ku).HasMaxLength(255).IsUnicode().IsRequired(false);

            builder.Property(p => p.Summary_Ar).HasMaxLength(255).IsUnicode().IsRequired(false);

            builder.Property(p => p.Body).IsUnicode().IsRequired(false);

            builder.Property(p => p.Body_Ku).IsUnicode().IsRequired(false);

            builder.Property(p => p.Body_Ar).IsUnicode().IsRequired(false);

            builder.Property(p => p.ImageUrl).HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.ImageUrl_Ku).HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.ImageUrl_Ar).HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.ThumbnailUrl).HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.ThumbnailUrl_Ku).HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.ThumbnailUrl_Ar).HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.IsPublished).IsRequired();

            builder.Property(p => p.ReaderType).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ContentCategory).WithMany(p => p.Articles).HasForeignKey(p => p.ContentCategoryId).IsRequired();
        }
    }
}
