using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ConsultancyMessageConfiguration : IEntityTypeConfiguration<ConsultancyMessage>
    {
        public void Configure(EntityTypeBuilder<ConsultancyMessage> builder)
        {
            builder.ToTable("ConsultancyMessage");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Content).IsUnicode().HasMaxLength(2048).IsRequired();

            builder.Property(p => p.Type).IsRequired();

            builder.Property(p => p.Status).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.Property(p => p.DeletedAt).IsRequired(false).HasColumnType("datetime2");

            builder.Property(p => p.ConsultancyId).IsRequired();

            builder.Property(p => p.ServiceSupplyId).IsRequired();

            builder.Property(p => p.PersonId).IsRequired();

            builder.HasOne(pm => pm.Consultancy).WithMany(u => u.ConsultancyMessages).HasForeignKey(pm => pm.ConsultancyId).IsRequired();

            builder.HasOne(pm => pm.ServiceSupply).WithMany(u => u.ConsultancyMessages).HasForeignKey(pm => pm.ServiceSupplyId).IsRequired();

            builder.HasOne(pm => pm.Person).WithMany(u => u.ConsultancyMessages).HasForeignKey(pm => pm.PersonId).IsRequired();
        }
    }
}
