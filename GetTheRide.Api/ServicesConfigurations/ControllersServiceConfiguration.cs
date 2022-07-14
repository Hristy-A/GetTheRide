using GetTheRide.BL.Mappings;

namespace GetTheRide.Api.ServicesConfigurations
{
    internal static class ControllersServiceConfiguration
    {
        internal static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddMappings();
        }
    }
}
