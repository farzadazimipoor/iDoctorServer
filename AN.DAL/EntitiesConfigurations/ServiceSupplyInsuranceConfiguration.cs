using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ServiceSupplyInsuranceConfiguration : IEntityTypeConfiguration<ServiceSupplyInsurance>
    {
        public void Configure(EntityTypeBuilder<ServiceSupplyInsurance> builder)
        {
            builder.ToTable("ServiceSupplyInsurance");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Insurance).WithMany(p => p.ServiceSupplies).HasForeignKey(p => p.InsuranceId).IsRequired();

            builder.HasOne(p => p.ServiceSupply).WithMany(p => p.Insurances).HasForeignKey(p => p.ServiceSupplyId).IsRequired();
        }
    }
}
