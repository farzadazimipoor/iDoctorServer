using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class UsualSchedulePlanConfiguration : IEntityTypeConfiguration<UsualSchedulePlan>
    {
        public void Configure(EntityTypeBuilder<UsualSchedulePlan> builder)
        {
            builder.ToTable("UsualSchedulePlan");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.DayOfWeek).IsRequired();
            
            builder.Property(p => p.Shift).IsRequired();

            builder.Property(p => p.StartTime).HasMaxLength(8).IsRequired();

            builder.Property(p => p.EndTime).HasMaxLength(8).IsRequired();

            builder.Property(p => p.Prerequisite).IsRequired();

            builder.Property(p => p.MaxCount).IsRequired();

            builder.Property(p => p.ValidFromDate).IsRequired();

            builder.Property(p => p.ExpireDate).IsRequired();

            builder.HasOne(p => p.ServiceSupply).WithMany(p => p.UsualSchedulePlans).HasForeignKey(p => p.ServiceSupplyId).IsRequired();

            builder.HasOne(p => p.ShiftCenterService).WithMany(p => p.UsualSchedulePlans).HasForeignKey(p => p.ShiftCenterServiceId).IsRequired();
        }
    }
}
