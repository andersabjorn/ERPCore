using ERPCore.ConsoleUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ERPCore.ConsoleUI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext()
        {
            // Tom konstruktor behövs för manuell new()
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Denna behövs om man kör via DI senare
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Read connection string from environment variable first (production/CI),
                // then fall back to local development default.
                var connectionString =
                    Environment.GetEnvironmentVariable("ERPCORE_CONNECTION_STRING")
                    ?? "Server=(localdb)\\mssqllocaldb;Database=ERPCoreDb;Trusted_Connection=True;MultipleActiveResultSets=true";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}