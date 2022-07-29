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
                .HasMany<User>()
                .WithOne(x => x.Trip)
                .HasForeignKey(x => x.TripId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne<User>(t => t.Driver)
            //    .WithOne(u=>u.Trip)
            //    //.OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(t => t.DriverId).IsUnique();
        }
    }
}
