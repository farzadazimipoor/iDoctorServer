using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class InsuranceServiceConfiguration : IEntityTypeConfiguration<InsuranceService>
    {
        public void Configure(EntityTypeBuilder<InsuranceService> builder)
        {
            builder.ToTable("InsuranceService");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).IsUnicode().HasMaxLength(256).IsRequired(false);
            builder.Property(p => p.Title_Ku).IsUnicode().HasMaxLength(256).IsRequired(false);
            builder.Property(p => p.Title_Ar).IsUnicode().HasMaxLength(256).IsRequired(false);

            builder.Property(p => p.Summary).IsUnicode().HasMaxLength(512).IsRequired(false);
            builder.Property(p => p.Summary_Ku).IsUnicode().HasMaxLength(512).IsRequired(false);
            builder.Property(p => p.Summary_Ar).IsUnicode().HasMaxLength(512).IsRequired(false);

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Description_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.HasAttachments).IsRequired();

            builder.Property(p => p.Photo).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Insurance).WithMany(p => p.Documents).HasForeignKey(p => p.InsuranceId).IsRequired();
        }
    }
}
