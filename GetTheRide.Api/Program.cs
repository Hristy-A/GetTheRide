using Autofac.Extensions.DependencyInjection;
using GetTheRide.Api.MiddlewaresConfigurations;
using GetTheRide.Api.ServicesConfigurations;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Host
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        //.ConfigureContainer<ContainerBuilder>(builder =>
        //  builder.);
        ;

    DbContextServiceConfiguration.Configure(builder);

    ControllersServiceConfiguration.Configure(builder);

    MappingServiceConfiguration.Configure(builder);

    SwaggerServiceConfiguration.Configure(builder);

    var app = builder.Build();

    DevelopmentModeConfiguration.Configure(app);

    HttpsRedirectingConfiguration.Configure(app);

    AuthorizationConfiguration.Configure(app);

    ControllersConfiguration.Configure(app);

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
