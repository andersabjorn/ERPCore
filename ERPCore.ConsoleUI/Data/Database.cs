using ERPCore.ConsoleUI.Models;

namespace ERPCore.ConsoleUI.Data;

public static class Database
{

    public static void AddCustomer(string firstName, string lastName, string email, string phoneNumber)
    {
        using (var db = new AppDbContext())
        {
            var newCustomer = new Customer
            {
                CustomerNumber = "C-" + new Random().Next(1000, 9999).ToString(),
                
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
            };

            db.Customer.Add(newCustomer);

            db.SaveChanges();
        }
    }
}

