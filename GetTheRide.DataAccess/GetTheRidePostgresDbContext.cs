using System.Reflection;
using GetTheRide.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GetTheRide.DataAccess
{
    public class GetTheRidePostgresDbContext : GetTheRideDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder()
            {
                Database = "gettheride",
                Username = "postgres",
                Password = "admin"
            };

            //optionsBuilder.UseNpgsql(new dbcon)

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(GetTheRideDbContext))!);

            base.OnModelCreating(modelBuilder);
        }
    }
}