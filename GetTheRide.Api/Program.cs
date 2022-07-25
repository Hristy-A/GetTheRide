using GetTheRide.Api.Infrastructure;
using GetTheRide.Api.MiddlewaresConfigurations;
using GetTheRide.Api.ServicesConfigurations;
using NLog;
using NLog.Web;

//HACK: Может быть врапнуть проверку и глобальное логирование в метод каким-либо способом, или оставить как есть?

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.UseNLogLoggingSystem();

    // Configuring services with using Autofac
    ServicesConfigurator.ConfigureServicesWithAutofac(builder);

    // Configuring services with using standart Microsoft DI
    // ServicesConfigurator.ConfigureServicesWithDefaultDI(builder);

    var app = builder.Build();

    DevelopmentModeConfiguration.Configure(app);

    HttpsRedirectingConfiguration.Configure(app);

    AuthorizationConfiguration.Configure(app);

    ControllersConfiguration.Configure(app);

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of unhandled exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
