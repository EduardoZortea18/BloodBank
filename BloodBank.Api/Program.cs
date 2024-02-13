using BloodBank.Application.Commands.CreateDonator;
using BloodBank.Application.Validators;
using BloodBank.Domain.Repositories;
using BloodBank.Infra;
using BloodBank.Infra.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<BloodBankContext>(opts => opts.UseNpgsql(connectionString));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IBloodStockRepository, BloodStockRepository>();
builder.Services.AddTransient<IDonationRepository, DonationRepository>();
builder.Services.AddTransient<IDonatorRepository, DonatorRepository>();

builder.Services.AddControllers()
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateDonatorCommandValidator>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateDonatorCommand).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
