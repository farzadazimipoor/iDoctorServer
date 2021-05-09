using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ShiftCenterMessageConfiguration : IEntityTypeConfiguration<ShiftCenterMessage>
    {
        public void Configure(EntityTypeBuilder<ShiftCenterMessage> builder)
        {
            builder.ToTable("ShiftCenterMessage");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.MessageId).IsRequired(false);

            builder.Property(p => p.MessageStatus).IsRequired(false);

            builder.Property(p => p.SendingDate).IsRequired();

            builder.Property(p => p.Type).IsRequired();

            builder.Property(p => p.Category).IsRequired();

            builder.Property(p => p.About).IsRequired();

            builder.Property(p => p.MessageBody).IsUnicode().HasMaxLength(500).IsRequired();

            builder.Property(p => p.Recipient).IsUnicode().HasMaxLength(128).IsRequired();

            builder.Property(p => p.SendingRetryCount).IsRequired();

            builder.Property(p => p.GettingStatusCount).IsRequired();

            builder.HasOne(p => p.ShiftCenter).WithMany(p => p.PoliclinicMessages).HasForeignKey(p => p.ShiftCenterId).IsRequired();

            builder.HasOne(pm => pm.ReceiverPerson).WithMany(u => u.ShiftCenterMessages).HasForeignKey(pm => pm.ReceiverPersonId).IsRequired();

            builder.HasOne(pm => pm.Appointment).WithMany(u => u.ShiftCenterMessages).HasForeignKey(pm => pm.AppointmentId).IsRequired();
        }
    }
}
