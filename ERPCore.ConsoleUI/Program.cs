using ERPCore.ConsoleUI.Data;
using ERPCore.ConsoleUI.Infrastructure.Repositories; 
using ERPCore.ConsoleUI.Interfaces;                
using ERPCore.ConsoleUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string apiKey = config["OpenAI:ApiKey"];
string modelId = "gpt-4o";

// --- START AI KOD ---
var builder = Kernel.CreateBuilder();
builder.AddOpenAIChatCompletion(modelId, apiKey);
var kernel = builder.Build();

Console.WriteLine("--- Starta AI-Motorn ---");
Console.Write("Testar anslutning till OpenAI...");

try
{
    var chatService = kernel.GetRequiredService<IChatCompletionService>();
    var response = await chatService.GetChatMessageContentAsync("Svara med ett enda ord: Fungerar du?");

    Console.WriteLine("\n✅ Kontakt etablerad!");
    Console.WriteLine($"AI svarar: {response}");
}
catch (Exception ex)
{
    Console.WriteLine("\n❌ Något gick fel med AI:n:");
    Console.WriteLine(ex.Message);
}

Console.WriteLine("\nTryck på valfri knapp för att öppna huvudmenyn...");
Console.ReadKey();
// --- SLUT AI KOD ---


bool keepRunning = true;
while (keepRunning)
{
    Console.Clear();

Console.WriteLine("\n🎅 Systemet online. God Jul Anders! Dags att bygga framtiden. 🎅\n");
    Console.WriteLine("1. Visa Kunder (Gammalt sätt)");
    Console.WriteLine("2. Lägg till ny kund");
    Console.WriteLine("3. Visa Produkter (Repository Pattern - NYTT!)");
    Console.WriteLine("0. Avsluta");

    Console.Write("Ditt val: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ShowAllCustomers();
            break;
        case "2":
            // Logik för att lägga till kund
            Console.Clear();
            Console.WriteLine("--- Lägg till ny kund ---");
            Console.Write("Förnamn: ");
            string fName = Console.ReadLine();
            Console.Write("Efternamn: ");
            string lName = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Telefon: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Sparar till databasen...");
            // OBS: Jag antar att du har kvar din Database-klass, annars byt till context här.
            Database.AddCustomer(fName, lName, email, phoneNumber); 

            Console.WriteLine("Klart! Kunden är tillagd.");
            Console.WriteLine("Tryck på valfri knapp för att återgå.");
            Console.ReadKey();
            break;

        case "3":                
            ShowAllProducts(); // Här kör vi din nya kod!
            break;

        case "0":
            keepRunning = false;
            break;
        
        default:
            Console.WriteLine("Ogiltigt val, försök igen.");
            Console.ReadKey();
            break;
    }
}

// --- METODER LIGGER HÄR NERE, PRYDLIGT SEPARERADE ---

void ShowAllCustomers()
{
    Console.Clear();
    Console.WriteLine("---- Kundlista ----");

    using (var context = new AppDbContext())
    {
        var customers = context.Customers.ToList();

        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.Id} Name: {customer.FirstName} {customer.LastName}");
        }
    }
    
    Console.WriteLine("\nTryck på valfri knapp för att återgå");
    Console.ReadKey();
}

void ShowAllProducts()
{
    Console.Clear();
    Console.WriteLine("---- Produktlista (Från Repository) ----");

    using (var context = new AppDbContext())
    {
        // Här använder Lagerchef!
        IProductRepository repo = new ProductRepository(context);
        
        var products = repo.GetAll();

        foreach (var p in products)
        {
            Console.WriteLine($"ProduktID: {p.Id} - {p.Name}");
        }
    }
    
    Console.WriteLine("\nTryck på valfri knapp för att återgå");
    Console.ReadKey();
}