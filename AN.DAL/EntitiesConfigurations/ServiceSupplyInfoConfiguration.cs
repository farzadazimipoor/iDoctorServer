using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class ServiceSupplyInfoConfiguration : IEntityTypeConfiguration<ServiceSupplyInfo>
    {
        public void Configure(EntityTypeBuilder<ServiceSupplyInfo> builder)
        {
            builder.ToTable("ServiceSupplyInfo");

            builder.HasKey(p => p.ServiceSupplyId);

            builder.Property(p => p.ServiceSupplyId).IsRequired();

            builder.Property(p => p.MedicalCouncilNumber).HasMaxLength(10).IsRequired();

            builder.Property(p => p.Bio).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Bio_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Bio_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.Picture).HasMaxLength(255).IsRequired(false);

            builder.Property(p => p.Website).HasMaxLength(255).IsRequired(false);

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(1000).IsRequired();

            builder.Property(p => p.WorkExperience).IsRequired().HasDefaultValue(0);

            builder.Property(p => p.Phone).HasMaxLength(15).IsRequired();

            builder.Property(p => p.AcceptionDate).IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
