using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class DoctorActivityLogConfiguration : IEntityTypeConfiguration<DoctorActivityLog>
    {
        public void Configure(EntityTypeBuilder<DoctorActivityLog> builder)
        {
            builder.ToTable("DoctorActivityLog");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Date).IsRequired();

            builder.Property(p => p.Action).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ServiceSupply).WithMany(p => p.ActivityLogs).HasForeignKey(p => p.ServiceSupplyId).IsRequired();
        }
    }
}
