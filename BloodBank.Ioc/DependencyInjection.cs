using BloodBank.Application.Commands.CreateDonator;
using BloodBank.Domain.Repositories;
using BloodBank.Infra;
using BloodBank.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Ioc
{
    public static class DependencyInjection
    {
        public static void ConfigureInjection(this IServiceCollection services, IConfiguration configuration)
        {
            AddData(services, configuration);
            AddApplication(services);
        }

        public static void AddData(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<BloodBankContext>(opts => opts.UseNpgsql(connectionString));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IBloodStockRepository, BloodStockRepository>();
            services.AddTransient<IDonationRepository, DonationRepository>();
            services.AddTransient<IDonatorRepository, DonatorRepository>();
        }

        public static void AddApplication(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateDonatorCommand).Assembly));
        }
    }
}
