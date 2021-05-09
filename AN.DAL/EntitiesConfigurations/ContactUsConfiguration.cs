using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.ToTable("ContactUs");

            builder.HasKey(p => p.Id);           

            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();

            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

            builder.Property(p => p.Mobile).HasMaxLength(15).IsRequired(false);

            builder.Property(p => p.Topic).IsUnicode().HasMaxLength(100).IsRequired();

            builder.Property(p => p.Message).IsUnicode().HasMaxLength(1000).IsRequired();

            builder.Property(p => p.IsArchived).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.IsUnread).IsRequired().HasDefaultValue(true);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");            
        }
    }
}
