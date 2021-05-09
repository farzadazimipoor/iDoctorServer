using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class EventLogConfiguration : IEntityTypeConfiguration<EventLog>
    {
        public void Configure(EntityTypeBuilder<EventLog> builder)
        {
            builder.ToTable("EventLog");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Controller).IsUnicode().HasMaxLength(256).IsRequired(false);

            builder.Property(p => p.Action).IsUnicode().HasMaxLength(256).IsRequired(false);

            builder.Property(p => p.IP).IsUnicode().HasMaxLength(50).IsRequired(false);

            builder.Property(p => p.Parameters).IsUnicode().IsRequired(false);

            builder.Property(p => p.Date).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
