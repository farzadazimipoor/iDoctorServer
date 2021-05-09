using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class BlockedIpConfiguration : IEntityTypeConfiguration<BlockedIp>
    {
        public void Configure(EntityTypeBuilder<BlockedIp> builder)
        {
            builder.ToTable("BlockedIp");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.IpAddress).HasMaxLength(45).IsRequired();           

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
           
        }
    }
}
