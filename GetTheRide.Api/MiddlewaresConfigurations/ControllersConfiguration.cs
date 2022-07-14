namespace GetTheRide.Api.MiddlewaresConfigurations
{
    public class ControllersConfiguration
    {
        internal static void Configure(WebApplication app)
        {
            app.MapControllers();
        }
    }
}
