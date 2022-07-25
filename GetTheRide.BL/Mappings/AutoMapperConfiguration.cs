using GetTheRide.Domain;
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
                    .ForMember(d => d.Name, o => o.MapFrom(s => $"{s.FirstName} {s.LastName}"))
                    .ForMember(d => d.Vehicle, o => o.MapFrom(s => s.Vehicle!.Name))
                    .ReverseMap();

                //a.CreateMap<Driver, Vehicle>()
                //    .ForMember(v => v.Name, o => o.MapFrom(d => d.Name))
                //    .ForMember(v => v.Seats, o => o.);

                a.CreateMap<Domain.Trip, Trip>()
                    .ForMember(d => d.State, o => o.MapFrom(s => s.State.ToString()))
                    .ReverseMap();
                    //.ForMember(d => d.State, o => o.MapFrom(s => GetTheRide enum value s.State.ToString()))
            });

            return serviceCollection;
        }
    }
}