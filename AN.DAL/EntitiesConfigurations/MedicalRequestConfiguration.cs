using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class MedicalRequestConfiguration : IEntityTypeConfiguration<MedicalRequest>
    {
        public void Configure(EntityTypeBuilder<MedicalRequest> builder)
        {
            builder.ToTable("MedicalRequest");

            builder.Property(p => p.Note).IsUnicode().HasMaxLength(1000).IsRequired();

            builder.Property(p => p.Date).IsUnicode().IsRequired();

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.RequestedCountry).WithMany(p => p.MedicalRequests).HasForeignKey(p => p.RequestedCountryId).IsRequired();

            builder.HasOne(p => p.RequesterPerson).WithMany(p => p.MedicalRequests).HasForeignKey(p => p.RequesterPersonId).IsRequired();
        }
    }
}
