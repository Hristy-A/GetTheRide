using Microsoft.Extensions.DependencyInjection;

namespace GetTheRide.BL.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddMappings(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(a =>
            {
                a.CreateMap<Domain.User, Driver>()
                    .ForMember(d => d.Name, o => o.MapFrom(s => $"{s.FirstName} {s.LastName}"));

                a.CreateMap<Domain.Vehicle, Vehicle>();

                a.CreateMap<Domain.Trip, Trip>()
                    .ForMember(d => d.State, o => o.MapFrom(s => s.State.ToString()));
            });

            return serviceCollection;
        }
    }
}
