using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infra.Configuration
{
    public class DonationConfiguration : BaseConfiguration<Donation>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Donation> builder)
        {
            builder.Property(x => x.Quantity)
                .HasMaxLength(470)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

            builder
                 .HasOne(x => x.Donator)
                 .WithMany(d => d.Donations)
                 .HasForeignKey(x => x.DonatorId)
                 .IsRequired();
        }
    }
}
