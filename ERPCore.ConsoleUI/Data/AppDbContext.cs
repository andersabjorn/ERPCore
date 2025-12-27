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
            // Om vi inte redan har fått inställningar via Dependency Injection...
            if (!optionsBuilder.IsConfigured)
            {
                // ...så använder vi den här hårdkodade anslutningen direkt!
                // Detta funkar alltid för lokal utveckling.
                var connectionString =
                    "Server=(localdb)\\mssqllocaldb;Database=ERPCoreDb;Trusted_Connection=True;MultipleActiveResultSets=true";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}