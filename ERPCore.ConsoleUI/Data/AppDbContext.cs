using ERPCore.ConsoleUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Denna rad är ny!

namespace ERPCore.ConsoleUI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SalesOrder> SalesOrders { get; set; }
    public DbSet<OrderRow> OrderRows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 1. Här säger vi åt programmet att leta efter appsettings.json
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // 2. Hämta texten som står under "DefaultConnection" i filen
        string connectionString = config.GetConnectionString("DefaultConnection");

        // 3. Koppla upp mot databasen med den texten
        optionsBuilder.UseSqlServer(connectionString);
    }
}