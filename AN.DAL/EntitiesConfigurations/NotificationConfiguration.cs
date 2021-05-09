using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.PersonId).IsRequired(false);

            builder.Property(p => p.Title).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Title_Ku).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.Title_Ar).IsUnicode().HasMaxLength(50).IsRequired();

            builder.Property(p => p.Text).IsUnicode().HasMaxLength(255).IsRequired();
            builder.Property(p => p.Text_Ku).IsUnicode().HasMaxLength(255).IsRequired();
            builder.Property(p => p.Text_Ar).IsUnicode().HasMaxLength(255).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.ValidUntil).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}