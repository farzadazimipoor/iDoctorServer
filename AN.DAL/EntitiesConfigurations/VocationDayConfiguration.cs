using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class VocationDayConfiguration : IEntityTypeConfiguration<VocationDay>
    {
        public void Configure(EntityTypeBuilder<VocationDay> builder)
        {
            builder.ToTable("VocationDay");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Date).IsRequired();

            builder.Property(p => p.DayOfWeek).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(500).IsRequired(false);
            
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");            
        }
    }
}
