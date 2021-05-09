using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class DoctorExpertiseConfiguration : IEntityTypeConfiguration<DoctorExpertise>
    {
        public void Configure(EntityTypeBuilder<DoctorExpertise> builder)
        {
            builder.ToTable("DoctorExpertise");

            builder.HasKey(k => new
            {
                k.ServiceSupplyId,
                k.ExpertiseId
            });

            builder.HasOne(p => p.ServiceSupply).WithMany(p => p.DoctorExpertises).HasForeignKey(p => p.ServiceSupplyId).IsRequired();

            builder.HasOne(p => p.Expertise).WithMany(p => p.DoctorExpertises).HasForeignKey(p => p.ExpertiseId).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");           
        }
    }
}
