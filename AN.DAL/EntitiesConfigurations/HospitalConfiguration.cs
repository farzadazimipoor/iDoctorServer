using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.ToTable("Hospital");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(100).IsRequired();
            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(100).IsRequired();
            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(100).IsRequired();

            builder.Property(p => p.IsGovernmental).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.Type).IsRequired();

            builder.Property(p => p.Address).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.Address_Ku).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.Address_Ar).IsUnicode().HasMaxLength(255).IsRequired(false);

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.FinalBookMessage).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.FinalBookMessage_Ku).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.FinalBookMessage_Ar).IsUnicode().HasMaxLength(255).IsRequired(false);

            builder.Property(p => p.FinalBookSMSMessage).IsUnicode().HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.FinalBookSMSMessage_Ku).IsUnicode().HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.FinalBookSMSMessage_Ar).IsUnicode().HasMaxLength(50).IsRequired(false);

            builder.Property(p => p.Location).IsRequired(false);

            builder.Property(p => p.IsApproved).IsRequired(true).HasDefaultValue(false);

            builder.Property(p => p.Notification).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Notification_Ku).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Notification_Ar).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(x => x._PhoneNumbers).HasColumnName("PhoneNumbers");

            builder.Property(p => p.Logo).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.City).WithMany(p => p.Hospitals).HasForeignKey(p => p.CityId).IsRequired();
        }
    }
}
