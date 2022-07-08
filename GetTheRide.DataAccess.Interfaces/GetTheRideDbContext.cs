using GetTheRide.Domain;
using Microsoft.EntityFrameworkCore;

namespace GetTheRide.DataAccess.Interfaces
{
    public abstract class GetTheRideDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
    }
}