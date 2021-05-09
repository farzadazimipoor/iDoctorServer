using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ScheduleInsuranceConfiguration : IEntityTypeConfiguration<ScheduleInsurance>
    {
        public void Configure(EntityTypeBuilder<ScheduleInsurance> builder)
        {
            builder.ToTable("ScheduleInsurance");

            builder.HasKey(x => new
            {
                x.ScheduleId,
                x.ServiceSupplyInsuranceId
            });

            builder.Property(p => p.AdmissionCapacity).IsRequired();

            builder.HasOne(p => p.Insurance).WithMany(p => p.Schedules).HasForeignKey(p => p.ServiceSupplyInsuranceId).IsRequired();

            builder.HasOne(p => p.Schedule).WithMany(p => p.Insurances).HasForeignKey(p => p.ScheduleId).IsRequired();
        }
    }
}
