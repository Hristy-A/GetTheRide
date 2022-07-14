namespace GetTheRide.Api.MiddlewaresConfigurations
{
    internal static class HttpsRedirectingConfiguration
    {
        internal static void Configure(WebApplication app)
        {
            app.UseHttpsRedirection();
        }
    }
}
