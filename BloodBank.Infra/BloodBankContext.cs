using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BloodBank.Infra
{
    public class BloodBankContext : DbContext
    {
        public BloodBankContext(DbContextOptions<BloodBankContext> options) : base(options)
        {

        }

        public DbSet<Donator> Donators { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
