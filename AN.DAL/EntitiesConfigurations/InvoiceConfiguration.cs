using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.VisitDate).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Patient).WithMany(p => p.Invoices).HasForeignKey(p => p.PatientId).IsRequired();

            builder.HasOne(p => p.Appointment).WithMany(p => p.Invoices).HasForeignKey(p => p.AppointmentId).IsRequired(false);
        }
    }
}
