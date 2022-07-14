namespace GetTheRide.Api.MiddlewaresConfigurations
{
    internal static class DevelopmentModeConfiguration
    {
        internal static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
