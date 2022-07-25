using GetTheRide.DataAccess;
using GetTheRide.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GetTheRide.Api.ServicesConfigurations
{
    internal static class DbContextServiceConfiguration
    {
        internal static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<GetTheRideDbContext, GetTheRidePostgresDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
        }
    }
}
