using AN.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AN.DAL.EntitiesConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.NamePrefix).HasMaxLength(20).IsRequired(false);

            builder.Property(p => p.FirstName).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.FirstName_Ku).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.FirstName_Ar).IsUnicode().HasMaxLength(50).IsRequired();

            builder.Property(p => p.SecondName).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.SecondName_Ku).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.SecondName_Ar).IsUnicode().HasMaxLength(50).IsRequired();

            builder.Property(p => p.ThirdName).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.ThirdName_Ku).IsUnicode().HasMaxLength(50).IsRequired();
            builder.Property(p => p.ThirdName_Ar).IsUnicode().HasMaxLength(50).IsRequired();

            builder.Property(p => p.Mobile).HasMaxLength(10).IsRequired();

            builder.Property(p => p.Email).HasMaxLength(256).IsRequired(false);

            builder.Property(p => p.Gender).IsRequired();

            builder.Property(p => p.IsEmployee).IsRequired();

            builder.Property(p => p.UniqueId).HasMaxLength(5).IsRequired(false);

            builder.Property(p => p.Age).IsRequired(false);

            builder.Property(p => p.Avatar).HasMaxLength(255).IsRequired(false);

            builder.Property(p => p.MobileConfirmed).IsRequired().HasDefaultValue(false);

            builder.Property(p => p.ZipCode).HasMaxLength(50).IsRequired(false);

            builder.Property(p => p.Address).IsUnicode().HasMaxLength(500).IsRequired(false);           

            builder.Property(p => p.Description).IsUnicode().HasMaxLength(1000).IsRequired(false);                  

            builder.Property(p => p.Birthdate).IsRequired(false);

            builder.Property(p => p.Weight).IsRequired(false);

            builder.Property(p => p.Height).IsRequired(false);

            builder.Property(p => p.IdNumber).HasMaxLength(50).IsRequired(false);

            builder.Property(p => p.MarriageStatus).IsRequired(false);

            builder.Property(p => p.Language).IsRequired(false);

            builder.Property(p => p.BloodType).IsRequired(false);

            builder.Property(p => p._FcmInstanceIds).IsRequired(false);

            builder.Property(p => p.IsApproved).IsRequired().HasDefaultValue(true);

            builder.Property(p => p.CreationPlaceId).IsRequired(false);

            builder.Property(p => p.CreatorRole).IsRequired(false);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedAt).IsRequired(false).HasColumnType("datetime2");

            builder.HasOne(p => p.Parent).WithMany(p => p.Children).HasForeignKey(p => p.ParentId).IsRequired(false);

            builder.HasOne(p => p.PatientPersonInfo).WithOne(p => p.Person).HasForeignKey<PatientPersonInfo>(p => p.PersonId);
        }
    }
}
