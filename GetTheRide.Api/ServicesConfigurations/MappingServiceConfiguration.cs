using GetTheRide.BL.Mappings;

namespace GetTheRide.Api.ServicesConfigurations
{
    public static class MappingServiceConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddMappings();
        }
    }
}
