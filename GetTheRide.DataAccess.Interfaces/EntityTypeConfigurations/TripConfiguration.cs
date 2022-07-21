using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetTheRide.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetTheRide.DataAccess.Interfaces.EntityTypeConfigurations
{
    internal class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne(t => t.Driver)
                .WithOne(u => u.Trip)
                .HasForeignKey("DriverId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(t => t.Passengers)
                .WithOne(u => u.Trip)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
