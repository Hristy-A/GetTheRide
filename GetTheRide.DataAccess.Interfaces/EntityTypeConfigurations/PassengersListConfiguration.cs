using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using GetTheRide.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetTheRide.DataAccess.Interfaces.EntityTypeConfigurations
{
    public class UserTripConfiguration : IEntityTypeConfiguration<UserTrip>
    {
        public void Configure(EntityTypeBuilder<UserTrip> builder)
        {
            builder.HasKey(ut => ut.Id);

            builder
                .HasOne(ut => ut.Trip)
                .WithMany(t => t.Passengers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey("TripId");

            builder
                .HasOne(ut => ut.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey("UserId");
        }
    }
}
