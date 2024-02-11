﻿using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infra.Configuration
{
    public class BloodStockConfiguration : BaseConfiguration<BloodStock>
    {
        public override void ConfigureEntity(EntityTypeBuilder<BloodStock> builder)
        {
            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.BloodType)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.RhFactor)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}