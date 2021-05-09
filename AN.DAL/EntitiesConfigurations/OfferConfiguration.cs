using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offer");

            builder.HasKey(p => p.Id);

            // Title
            builder.Property(p => p.Title).HasMaxLength(50).IsUnicode().IsRequired(false);
            builder.Property(p => p.Title_Ar).HasMaxLength(50).IsUnicode().IsRequired(false);
            builder.Property(p => p.Title_Ku).HasMaxLength(50).IsUnicode().IsRequired(false);

            // Summary
            builder.Property(p => p.Summary).HasMaxLength(255).IsUnicode().IsRequired(false);
            builder.Property(p => p.Summary_Ku).HasMaxLength(255).IsUnicode().IsRequired(false);
            builder.Property(p => p.Summary_Ar).HasMaxLength(255).IsUnicode().IsRequired(false);

            // Description
            builder.Property(p => p.Description).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.StartDateTime).IsRequired(false);

            builder.Property(p => p.EndDateTime).IsRequired(false);

            builder.Property(p => p.MaxCount).IsRequired(false);

            builder.Property(p => p.RemainedCount).IsRequired(false);

            builder.Property(p => p.Status).IsRequired();
           
            builder.Property(p => p.Code).HasMaxLength(10).IsRequired();

            builder.Property(p => p.Type).IsRequired();

            // Photo
            builder.Property(p => p.Photo).IsRequired();
            builder.Property(p => p.Photo_Ar).IsRequired(false);
            builder.Property(p => p.Photo_Ku).IsRequired(false);

            builder.Property(p => p.StartAt).IsRequired();

            builder.Property(p => p.ExpiredAt).IsRequired();

            builder.Property(p => p.SendNotification).HasDefaultValue(false).IsRequired();

            // Notification Title
            builder.Property(p => p.NotificationTitle).IsUnicode().HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.NotificationTitle_Ku).IsUnicode().HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.NotificationTitle_Ar).IsUnicode().HasMaxLength(50).IsRequired(false);

            // Notification Body
            builder.Property(p => p.NotificationBody).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.NotificationBody_Ku).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.NotificationBody_Ar).IsUnicode().HasMaxLength(255).IsRequired(false);

            builder.Property(p => p.ServiceSupplyId).IsRequired();        

            builder.Property(p => p.DiscountPercentange).IsRequired(false);        

            builder.Property(p => p.OldPrice).IsRequired(false).HasColumnType("decimal(19,4)");

            builder.Property(p => p.CurrentPrice).IsRequired(false).HasColumnType("decimal(19,4)");

            builder.Property(p => p.ShowDiscountBanner).IsRequired(true);

            builder.Property(p => p.CurrencyType).IsRequired(true);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ServiceSupply).WithMany(p => p.Offers).HasForeignKey(p => p.ServiceSupplyId).IsRequired();

            builder.HasOne(p => p.ShiftCenterService).WithMany(p => p.Offers).HasForeignKey(p => p.ShiftCenterServiceId).IsRequired(false);
        }
    }
}
