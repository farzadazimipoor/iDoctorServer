using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("InvoiceItems");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CustomServiceName).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(19,4)");           

            builder.Property(p => p.Note).IsUnicode().HasMaxLength(1000).IsRequired(false);           

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Invoice).WithMany(p => p.InvoiceItems).HasForeignKey(p => p.InvoiceId).IsRequired();

            builder.HasOne(p => p.ShiftCenterService).WithMany(p => p.InvoiceItems).HasForeignKey(p => p.ShiftCenterCerviceId).IsRequired(false);           
        }
    }
}
