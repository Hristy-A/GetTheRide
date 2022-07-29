using Autofac;
using Autofac.Extensions.DependencyInjection;
using GetTheRide.Api.ServicesConfigurations.Autofac;
using GetTheRide.BL.Mappings;
using GetTheRide.DataAccess;
using GetTheRide.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Logging
    .ClearProviders()
    .AddNLog(new NLogLoggingConfiguration(builder.Configuration.GetRequiredSection("NLog")));

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
        builder.RegisterModule(new AppConfiguration()));

builder.Services
    .AddDbContext<GetTheRideDbContext, GetTheRidePostgresDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
    })
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddMappings()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
