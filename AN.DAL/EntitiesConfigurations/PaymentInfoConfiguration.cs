using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PaymentInfoConfiguration : IEntityTypeConfiguration<PaymentInfo>
    {
        public void Configure(EntityTypeBuilder<PaymentInfo> builder)
        {
            builder.ToTable("PaymentInfo");

            builder.HasKey(p => p.AppointmentId);
           
            builder.Property(p => p.AppointmentId).IsRequired();

            builder.Property(p => p.OrderId).IsUnicode().IsRequired();

            builder.Property(p => p.Price).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired();

            builder.Property(p => p.SaleReferenceId).IsRequired();

            builder.Property(p => p.SaleOrderId).IsRequired();            

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");            
        }
    }
}
