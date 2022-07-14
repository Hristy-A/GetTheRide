namespace GetTheRide.Api.MiddlewaresConfigurations
{
    internal static class AuthorizationConfiguration
    {
        internal static void Configure(WebApplication app)
        {
            app.UseAuthorization();
        }
    }
}
