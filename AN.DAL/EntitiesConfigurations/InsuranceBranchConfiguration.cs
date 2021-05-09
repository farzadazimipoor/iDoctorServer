using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class InsuranceBranchConfiguration : IEntityTypeConfiguration<InsuranceBranch>
    {
        public void Configure(EntityTypeBuilder<InsuranceBranch> builder)
        {
            builder.ToTable("InsuranceBranch");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Address).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Address_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.Address_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.Location).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Insurance).WithMany(p => p.CityBranches).HasForeignKey(p => p.InsuranceId).IsRequired();

            builder.HasOne(p => p.City).WithMany(p => p.InsuranceBranches).HasForeignKey(p => p.CityId).IsRequired();
        }
    }
}
