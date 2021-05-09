using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ServiceSupplyRatingConfiguration : IEntityTypeConfiguration<ServiceSupplyRating>
    {
        public void Configure(EntityTypeBuilder<ServiceSupplyRating> builder)
        {
            builder.ToTable("ServiceSupplyRating");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Rating).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Person).WithMany(p => p.Rates).HasForeignKey(p => p.PersonId).IsRequired();

            builder.HasOne(p => p.ServiceSupply).WithMany(p => p.Rates).HasForeignKey(p => p.ServiceSupplyId).IsRequired();
        }
    }
}
