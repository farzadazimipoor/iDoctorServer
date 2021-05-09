using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ServiceSupplyConfiguration : IEntityTypeConfiguration<ServiceSupply>
    {
        public void Configure(EntityTypeBuilder<ServiceSupply> builder)
        {
            builder.ToTable("ServiceSupply");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.VisitPrice).IsRequired();

            builder.Property(p => p.PrePaymentPercent).IsRequired();

            builder.Property(p => p.PaymentType).IsRequired();

            builder.Property(p => p.Duration).IsRequired();

            builder.Property(p => p.OnlineReservationPercent).IsRequired();

            builder.Property(p => p.IsAvailable).IsRequired();

            builder.Property(p => p.StartReservationDate).IsRequired();

            builder.Property(p => p.ReservationRangeStartPoint).IsRequired();

            builder.Property(p => p.ReservationRangeEndPointPosition).IsRequired();

            builder.Property(p => p.ReservationRangeEndPointDiffMinutes).IsRequired();

            builder.Property(p => p.Notification).IsUnicode().HasMaxLength(500).IsRequired();
            builder.Property(p => p.Notification_Ku).IsUnicode().HasMaxLength(500).IsRequired();
            builder.Property(p => p.Notification_Ar).IsUnicode().HasMaxLength(500).IsRequired();

            builder.Property(p => p.ReservationType).IsRequired();

            builder.Property(p => p.TotalRaters).IsRequired(false);

            builder.Property(p => p.TotalRating).IsRequired(false);

            builder.Property(p => p.AverageRating).IsRequired(false);

            builder.Property(p => p.ConsultancyEnabled).IsRequired();

            builder.Property(p => p.PrescriptionPath).HasMaxLength(1000).IsRequired();

            builder.HasOne(pm => pm.ShiftCenter).WithMany(u => u.ServiceSupplies).HasForeignKey(pm => pm.ShiftCenterId).IsRequired();

            builder.HasOne(pm => pm.Person).WithMany(u => u.ServiceSupplies).HasForeignKey(pm => pm.PersonId).IsRequired();

            builder.HasOne(p => p.ServiceSupplyInfo).WithOne(p => p.ServiceSupply).HasForeignKey<ServiceSupplyInfo>(p => p.ServiceSupplyId);

            builder.Property(v => v._Vocations).HasColumnName("Vocations");
        }        
    }
}
