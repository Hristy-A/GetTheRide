using GetTheRide.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetTheRide.DataAccess.Interfaces.EntityTypeConfigurations
{
    internal class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder
                .HasMany(x => x.Passengers)
                .WithOne(u => u.PassengerTrip)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Driver)
                .WithOne(u => u.DriverTrip)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
