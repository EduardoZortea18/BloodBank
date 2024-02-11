using BloodBank.Domain.Entities;
using BloodBank.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BloodBank.Infra.Configuration
{
    public class DonatorConfiguration : BaseConfiguration<Donator>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Donator> builder)
        {
            builder.Property(x => x.BloodType)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.RhFactor)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.BirthDate)
                .IsRequired();

            builder.Property(x => x.FullName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.Weight)
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasConversion<string>()
                .IsRequired();

            builder.OwnsOne(x => x.Address)
                .Property(x => x.City)
                .HasMaxLength(25)
                .IsRequired();

            builder.OwnsOne(x => x.Address)
               .Property(x => x.PublicArea)
               .HasMaxLength(50)
               .IsRequired();

            builder.OwnsOne(x => x.Address)
               .Property(x => x.State)
               .HasMaxLength(25)
               .IsRequired();

            builder.OwnsOne(x => x.Address)
               .Property(x => x.ZipCode)
               .HasMaxLength(9)
               .IsRequired();

            builder
                .HasMany(x => x.Donations)
                .WithOne(d => d.Donator)
                .HasForeignKey(d => d.DonatorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
