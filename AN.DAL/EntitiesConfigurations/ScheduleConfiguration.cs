using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");

            builder.HasKey(p => p.Id);           

            builder.Property(p => p.Start_DateTime).IsRequired();

            builder.Property(p => p.End_DateTime).IsRequired();

            builder.Property(p => p.DayOfWeek).HasMaxLength(50).IsRequired();

            builder.Property(p => p.IsAvailable).IsRequired();

            builder.Property(p => p.MaxCount).IsRequired();           

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.ServiceSupplyId).IsRequired();

            builder.Property(p => p.Prerequisite).IsRequired();

            builder.Property(p => p.Shift).IsRequired();           

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ServiceSupply).WithMany(p => p.Schedules).HasForeignKey(p => p.ServiceSupplyId).IsRequired();

            builder.HasOne(p => p.ShiftCenterService).WithMany(p => p.Schedules).HasForeignKey(p => p.ShiftCenterServiceId).IsRequired();            
        }
    }
}
