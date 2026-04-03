using ERPCore.ConsoleUI.Models;

namespace ERPCore.ConsoleUI.Data;

public static class Database
{
    private static readonly Random _random = new();

    public static void AddCustomer(string firstName, string lastName, string email, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("FirstName cannot be empty.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("LastName cannot be empty.", nameof(lastName));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty.", nameof(email));

        using var db = new AppDbContext();
        var newCustomer = new Customer
        {
            CustomerNumber = "C-" + _random.Next(1000, 9999).ToString(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
        };

        db.Customers.Add(newCustomer);

        try
        {
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to save customer '{firstName} {lastName}'.", ex);
        }
    }
}
