namespace GetTheRide.Api.ServicesConfigurations
{
    internal static class SwaggerServiceConfiguration
    {
        internal static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}
