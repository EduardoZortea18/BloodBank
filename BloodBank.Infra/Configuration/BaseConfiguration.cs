using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infra.Configuration
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.Active);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}
