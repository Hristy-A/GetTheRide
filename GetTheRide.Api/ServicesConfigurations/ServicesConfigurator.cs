using Autofac;
using Autofac.Extensions.DependencyInjection;
using GetTheRide.Api.ServicesConfigurations.Autofac;

namespace GetTheRide.Api.ServicesConfigurations
{
    internal class ServicesConfigurator
    {
        internal static void ConfigureServicesWithDefaultDI(WebApplicationBuilder builder)
        {
            DbContextServiceConfiguration.Configure(builder);

            ControllersServiceConfiguration.Configure(builder);

            MappingServiceConfiguration.Configure(builder);

            SwaggerServiceConfiguration.Configure(builder);
        }

        public static void ConfigureServicesWithAutofac(WebApplicationBuilder builder)
        {
            builder.Host
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                    builder.RegisterModule(new AppConfiguration()));
            ;
        }
    }
}
