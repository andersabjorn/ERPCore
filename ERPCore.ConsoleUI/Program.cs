using ERPCore.ConsoleUI.Data;
using ERPCore.ConsoleUI.Infrastructure.Repositories; 
using ERPCore.ConsoleUI.Interfaces;                
using ERPCore.ConsoleUI.Models;
using ERPCore.ConsoleUI.Strategies; // <--- Viktig! För att hitta strategierna
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// --- KONFIGURATION ---
var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

using (var context = new AppDbContext())
{
    Console.WriteLine("🔨 Nollställer databasen (Reset)...");
    
    // 1. RADERA allt gammalt skräp (The Nuke)
    context.Database.EnsureDeleted(); 
    
    // 2. Skapa nytt fräscht hus
    context.Database.EnsureCreated(); 
    
    // 3. Fyll med data (Kunder OCH Produkter)
    DataSeeder.SeedData(context); 
}

bool keepRunning = true;
while (keepRunning)
{
    Console.Clear();
    Console.WriteLine("==================================================");
    Console.WriteLine("   ERP CORE - CONSOLE PROTOTYPE (FINAL BUILD)     ");
    Console.WriteLine("==================================================");
    Console.WriteLine("1. Visa Kunder (Database Class - Old School)");
    Console.WriteLine("2. Visa Produkter (Repository Pattern - Architecture)");
    Console.WriteLine("3. Skapa en VIP-Order (Strategy Pattern - Advanced)");
    Console.WriteLine("0. Avsluta");
    Console.WriteLine("--------------------------------------------------");

    Console.Write("Ditt val: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ShowAllCustomers();
            break;

        case "2":                
            ShowAllProducts(); 
            break;

        case "3":
            CreateTestOrder(); // Här testar vi din strategi!
            break;

        case "0":
            keepRunning = false;
            break;
        
        default:
            Console.WriteLine("Ogiltigt val.");
            Console.ReadKey();
            break;
    }
}

// --- METODER ---

void ShowAllCustomers()
{
    Console.Clear();
    Console.WriteLine("---- Kundlista ----");
    using (var context = new AppDbContext())
    {
        var customers = context.Customers.ToList();
        foreach (var c in customers)
        {
            Console.WriteLine($"ID: {c.Id} - {c.FirstName} {c.LastName}");
        }
    }
    Console.WriteLine("\nTryck valfri knapp...");
    Console.ReadKey();
}

void ShowAllProducts()
{
    Console.Clear();
    Console.WriteLine("---- Produktlista (Repository) ----");
    using (var context = new AppDbContext())
    {
        // Här bevisar du att du fattar Repository Pattern
        IProductRepository repo = new ProductRepository(context);
        var products = repo.GetAll();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id}: {p.Name} - {p.Price:C}");
        }
    }
    Console.WriteLine("\nTryck valfri knapp...");
    Console.ReadKey();
}

void CreateTestOrder()
{
    Console.Clear();
    Console.WriteLine("---- Strategy Pattern Test ----");

    // 1. Välj strategi (Här "injicerar" vi beroendet manuellt)
    Console.WriteLine("Applicerar VIP-strategi (10% rabatt)...");
    IDiscountStrategy vipStrategy = new VipDiscountStrategy();

    // 2. Skapa ordern med strategin
    SalesOrder order = new SalesOrder(vipStrategy);
    
    // 3. Lägg till lite "låtsas-produkter" (bara för att få en summa)
    order.TotalAmount = 1000m; // Vi säger att vi köpt för 1000 kr

    // 4. Räkna ut priset
    decimal finalPrice = order.GetFinalPrice();

    Console.WriteLine($"Ordervärde: {order.TotalAmount:C}");
    Console.WriteLine($"Att betala: {finalPrice:C}");
    
    if (finalPrice < 1000)
    {
        Console.WriteLine("✅ Succé! Rabatten drogs av korrekt.");
    }

    Console.WriteLine("\nTryck valfri knapp...");
    Console.ReadKey();
}