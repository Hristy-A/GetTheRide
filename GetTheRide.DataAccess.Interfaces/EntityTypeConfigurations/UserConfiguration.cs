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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(x => x.Vehicle)
                .WithOne(x => x.User)
                .HasForeignKey<Vehicle>(x => x.UserId);
        }
    }
}
