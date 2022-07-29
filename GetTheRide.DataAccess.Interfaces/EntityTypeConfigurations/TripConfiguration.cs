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
                .WithOne(x => x.PassengerTrip)
                .HasForeignKey(x => x.PassengerTripId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Driver)
                .WithOne(x => x.DriverTrip)
                .HasForeignKey<User>(x => x.DriverTripId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
