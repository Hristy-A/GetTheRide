using NLog.Web;

namespace GetTheRide.Api.Infrastructure
{
    internal static class AppConfigurationExtensions
    {
        internal static void UseNLogLoggingSystem(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
        }
    }
}
