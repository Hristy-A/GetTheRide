using System.Reflection;
using GetTheRide.DataAccess.EnumHelpers;
using GetTheRide.DataAccess.Interfaces;
using GetTheRide.Domain;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GetTheRide.DataAccess
{
    public class GetTheRidePostgresDbContext : GetTheRideDbContext
    {
        public GetTheRidePostgresDbContext()
        {
            
        }
        public GetTheRidePostgresDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(GetTheRideDbContext))!);

            modelBuilder.CreateTablesForAllEnums(typeof(TripState).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}