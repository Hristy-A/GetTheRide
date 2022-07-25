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
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
                .Property(v => v.Name)
                .HasMaxLength(100);

            builder
                .HasOne(v => v.User)
                .WithOne(u => u.Vehicle)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
