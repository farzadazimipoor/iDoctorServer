using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ShiftCenterConfiguration : IEntityTypeConfiguration<ShiftCenter>
    {
        public void Configure(EntityTypeBuilder<ShiftCenter> builder)
        {
            builder.ToTable("ShiftCenter");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().HasMaxLength(100).IsRequired();
            builder.Property(p => p.Name_Ku).IsUnicode().HasMaxLength(100).IsRequired();
            builder.Property(p => p.Name_Ar).IsUnicode().HasMaxLength(100).IsRequired();

            builder.Property(p => p.IsIndependent).IsRequired().HasDefaultValue(true);           

            builder.Property(p => p.Type).IsRequired();

            builder.Property(p => p.Address).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Address_Ku).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Address_Ar).IsUnicode().HasMaxLength(1000).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.KnownAsDoctorName).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.BookingRestrictionHours).IsRequired();

            builder.Property(p => p.FinalBookMessage).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.FinalBookMessage_Ku).IsUnicode().HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.FinalBookMessage_Ar).IsUnicode().HasMaxLength(255).IsRequired(false);

            builder.Property(p => p.FinalBookSMSMessage).IsUnicode().HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.FinalBookSMSMessage_Ku).IsUnicode().HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.FinalBookSMSMessage_Ar).IsUnicode().HasMaxLength(100).IsRequired(false);           

            builder.Property(p => p.Location).IsRequired(false);

            builder.Property(p => p.IsApproved).IsRequired(true).HasDefaultValue(false);

            builder.Property(p => p.Notification).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Notification_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Notification_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.AutomaticScheduleEnabled).IsRequired();

            builder.Property(p => p.ActiveDaysAhead).IsRequired();

            builder.Property(x => x._PhoneNumbers).HasColumnName("PhoneNumbers");

            builder.Property(x => x._Images).HasColumnName("Images");

            builder.Property(v => v._Vocations).HasColumnName("Vocations");

            builder.Property(b => b._FcmInstanceIds).HasColumnName("FcmInstanceIds");

            builder.Property(p => p.Logo).HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.PrescriptionPath).HasMaxLength(1000).IsRequired();

            builder.Property(p => p.SupportAppointments).HasDefaultValue(true).IsRequired();

            builder.Property(p => p.ShowInHealthBank).HasDefaultValue(false).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.City).WithMany(p => p.ShiftCenters).HasForeignKey(p => p.CityId).IsRequired(false);

            builder.HasOne(p => p.Clinic).WithMany(p => p.ShiftCenters).HasForeignKey(p => p.ClinicId).IsRequired(false);            
        }       
    }
}
