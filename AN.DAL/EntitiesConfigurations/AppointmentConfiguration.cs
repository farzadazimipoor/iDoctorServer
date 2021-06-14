using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Book_DateTime).IsRequired();

            builder.Property(p => p.Start_DateTime).IsRequired();

            builder.Property(p => p.End_DateTime).IsRequired();

            builder.Property(p => p.Status).IsRequired();

            builder.Property(p => p.Paymentstatus).IsRequired();

            builder.Property(p => p.ReservationChannel).IsRequired();

            builder.Property(p => p.IsAnnounced).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.ServiceSupplyId).IsRequired();

            builder.Property(p => p.PersonId).IsRequired();

            builder.Property(p => p.PatientInsuranceId).IsRequired(false);

            builder.Property(p => p.ShiftCenterServiceId).IsRequired();

            builder.Property(p => p.UniqueTrackingCode).HasMaxLength(10).IsRequired();

            builder.Property(p => p.PersonLocation).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ServiceSupply).WithMany(p => p.Appointments).HasForeignKey(p => p.ServiceSupplyId).IsRequired();

            builder.HasOne(p => p.Person).WithMany(p => p.Appointments).HasForeignKey(p => p.PersonId).IsRequired();

            builder.HasOne(p => p.PatientInsurance).WithMany(p => p.Appointments).HasForeignKey(p => p.PatientInsuranceId).IsRequired(false);

            builder.HasOne(p => p.ShiftCenterService).WithMany(p => p.Appointments).HasForeignKey(p => p.ShiftCenterServiceId).IsRequired();

            builder.HasOne(p => p.Offer).WithMany(p => p.Appointments).HasForeignKey(p => p.OfferId).IsRequired(false);

            // ONE - ONE Relation
            builder.HasOne(p => p.PaymentInfo).WithOne(p => p.Appointment).HasForeignKey<PaymentInfo>(p => p.AppointmentId);

            // ONE - ONE Relation
            builder.HasOne(p => p.Rate).WithOne(p => p.Appointment).HasForeignKey<ServiceSupplyRating>(p => p.AppointmentId);
        }
    }
}
