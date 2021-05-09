using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class UsualScheduleInsurancesConfiguration : IEntityTypeConfiguration<UsualScheduleInsurances>
    {
        public void Configure(EntityTypeBuilder<UsualScheduleInsurances> builder)
        {
            builder.ToTable("UsualScheduleInsurances");

            builder.HasKey(x => new
            {
                x.ScheduleId,
                x.ServiceSupplyInsuranceId
            });

            builder.Property(p => p.AdmissionCapacity).IsRequired();

            builder.HasOne(p => p.UsualSchedulePlan).WithMany(p => p.UsualScheduleInsurances).HasForeignKey(p => p.ScheduleId).IsRequired();

            builder.HasOne(p => p.Insurance).WithMany(p => p.UsualSchedules).HasForeignKey(p => p.ServiceSupplyInsuranceId).IsRequired();
        }
    }
}
