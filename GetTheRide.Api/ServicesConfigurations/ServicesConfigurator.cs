using Autofac;
using Autofac.Extensions.DependencyInjection;
using GetTheRide.Api.ServicesConfigurations.Autofac;
using GetTheRide.BL.Mappings;
using GetTheRide.DataAccess;
using GetTheRide.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using NLog.
using NLog.Config;

namespace GetTheRide.Api.ServicesConfigurations
{
    internal class ServicesConfigurator
    {
        internal static void ConfigureServicesWithDefaultDI(WebApplicationBuilder builder)
        {
            builder.Logging
                .ClearProviders()
                .AddNLog(LoggingConfiguration);

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
        }
    }
}
