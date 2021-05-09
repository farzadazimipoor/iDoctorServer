using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resource");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Key).IsRequired();

            builder.Property(p => p.Type).IsRequired();

            builder.Property(p => p.FilePath).HasMaxLength(1000).IsRequired();

            builder.Property(p => p.Downloads).IsRequired();

            builder.Property(p => p.Version).HasMaxLength(10).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");            
        }
    }
}
