using GetTheRide.Api.MiddlewaresConfigurations;
using GetTheRide.Api.ServicesConfigurations;

var builder = WebApplication.CreateBuilder(args);

DbContextServiceConfiguration.Configure(builder);

ControllersServiceConfiguration.Configure(builder);

SwaggerServiceConfiguration.Configure(builder);

var app = builder.Build();

DevelopmentModeConfiguration.Configure(app);

HttpsRedirectingConfiguration.Configure(app);

AuthorizationConfiguration.Configure(app);

ControllersConfiguration.Configure(app);

app.Run();
