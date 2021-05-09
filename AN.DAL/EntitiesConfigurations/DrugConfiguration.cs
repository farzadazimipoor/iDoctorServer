using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class DrugConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.ToTable("Drug");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.GenericName).IsUnicode().HasMaxLength(255).IsRequired();

            builder.Property(p => p.GenericName_Ku).IsUnicode().HasMaxLength(255).IsRequired();

            builder.Property(p => p.GenericName_Ar).IsUnicode().HasMaxLength(255).IsRequired();

            builder.Property(p => p.TradeName).IsUnicode().HasMaxLength(255).IsRequired();

            builder.Property(p => p.EffectMechanism).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.EffectMechanism_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.EffectMechanism_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.ConsumptionTypes).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.ConsumptionTypes_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.ConsumptionTypes_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.SideEffects).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.SideEffects_Ku).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.SideEffects_Ar).IsUnicode().HasMaxLength(1000).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");            
        }
    }
}
