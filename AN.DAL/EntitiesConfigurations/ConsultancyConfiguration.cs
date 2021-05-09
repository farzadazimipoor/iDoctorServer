using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    class ConsultancyConfiguration : IEntityTypeConfiguration<Consultancy>
    {
        public void Configure(EntityTypeBuilder<Consultancy> builder)
        {
            builder.ToTable("Consultancy");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Status).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.Property(p => p.StartedAt).IsRequired(false).HasColumnType("datetime2");

            builder.Property(p => p.FinishedAt).IsRequired(false).HasColumnType("datetime2");

            builder.Property(p => p.ServiceSupplyId).IsRequired();

            builder.Property(p => p.PersonId).IsRequired();

            builder.HasOne(pm => pm.ServiceSupply).WithMany(u => u.Consultancies).HasForeignKey(pm => pm.ServiceSupplyId).IsRequired();

            builder.HasOne(pm => pm.Person).WithMany(u => u.Consultancies).HasForeignKey(pm => pm.PersonId).IsRequired();
        }
    }
}
