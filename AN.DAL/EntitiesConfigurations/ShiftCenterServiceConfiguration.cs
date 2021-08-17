using AN.Core.Domain;
using AN.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ShiftCenterServiceConfiguration : IEntityTypeConfiguration<ShiftCenterService>
    {
        public void Configure(EntityTypeBuilder<ShiftCenterService> builder)
        {
            builder.ToTable("ShiftCenterService");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CurrencyType).IsRequired().HasDefaultValue(CurrencyType.USD);

            builder.Property(p => p.Price).IsRequired(false);

            builder.Property(p => p.PriceWithDiscount).IsRequired(false).HasColumnType("decimal(19,4)");

            builder.Property(p => p.Note).IsUnicode().HasMaxLength(256).IsRequired(false);

            builder.Property(p => p.Note_Ku).IsUnicode().HasMaxLength(256).IsRequired(false);

            builder.Property(p => p.Note_Ar).IsUnicode().HasMaxLength(256).IsRequired(false);

            builder.HasOne(pm => pm.ShiftCenter).WithMany(u => u.PolyclinicHealthServices).HasForeignKey(pm => pm.ShiftCenterId).IsRequired();

            builder.HasOne(pm => pm.Service).WithMany(u => u.ShiftCenterServices).HasForeignKey(pm => pm.HealthServiceId).IsRequired();
        }
    }
}
