using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class BlockedMobilesConfiguration : IEntityTypeConfiguration<BlockedMobiles>
    {
        public void Configure(EntityTypeBuilder<BlockedMobiles> builder)
        {
            builder.ToTable("BlockedMobiles");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Mobile).HasMaxLength(10).IsRequired();

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(500).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.ShiftCenter).WithMany(p => p.BlockedMobiles).HasForeignKey(p => p.ShiftCenterId).IsRequired();

        }
    }
}
