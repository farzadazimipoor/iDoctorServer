using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Order).IsRequired();
            builder.Property(p => p.ThumbnailUrl).IsRequired();
            builder.Property(p => p.Url).IsRequired();
            builder.Property(p => p.Size).IsRequired();
            builder.Property(p => p.DeleteUrl).IsRequired();
            builder.Property(p => p.FileType).IsRequired();
            builder.Property(p => p.Description).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.Owner).IsRequired();

            builder.Property(p => p.OwnerTableId).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}