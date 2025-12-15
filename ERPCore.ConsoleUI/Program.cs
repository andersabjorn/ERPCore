using ERPCore.ConsoleUI.Data;
using ERPCore.ConsoleUI.Models;
using Microsoft.EntityFrameworkCore;

bool keepRunning = true;

while (keepRunning)
{
    Console.Clear();

    Console.WriteLine("1. Visa Kunder");
    Console.WriteLine("2. Lägg till ny kund");
    Console.WriteLine("0. Avsluta");

    Console.Write("Ditt val: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ShowAllCustomers();
            break;
        case "2":
        {
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
            Database.AddCustomer(fName, lName, email, phoneNumber);

            Console.WriteLine("Klart! Kunden är tillagd.");
            Console.WriteLine("Tryck å valfri knapp för att återgå.");
            Console.ReadKey();
            break;
        }


        case "0":
            keepRunning = false;
            break;
        
        default:
            Console.WriteLine("Ogiltigt val, försök igen.");
            Console.ReadKey();
            break;
    }
}

void ShowAllCustomers()
{
    Console.Clear();
    Console.WriteLine("---- Kundlista ----");

    using (var context = new AppDbContext())
    {
        var customers = context.Customer.ToList();

        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.Id} Name: {customer.FirstName} {customer.LastName}");
            
        }
    }

    Console.WriteLine("\nTryck på valfri knapp för att återgå");
    Console.ReadKey();
}