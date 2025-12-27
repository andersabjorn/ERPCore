using ERPCore.ConsoleUI.Models;

namespace ERPCore.ConsoleUI.Data
{
    public static class DataSeeder
    {
        // En huvudmetod som anropar allt
        public static void SeedData(AppDbContext context)
        {
            SeedCustomers(context);
            SeedProducts(context);
        }

        private static void SeedCustomers(AppDbContext context)
        {
            if (context.Customers.Any()) return; // Redan klart

            Console.WriteLine("🌱 Genererar Kunder...");
            var firstNames = new[] { "Anders", "Erik", "Lena", "Kalle", "Lisa" };
            var lastNames = new[] { "Svensson", "Johansson", "Nilsson", "Andersson", "Björk" };
            var random = new Random();

            for (int i = 0; i < 50; i++)
            {
                string fName = firstNames[random.Next(firstNames.Length)];
                string lName = lastNames[random.Next(lastNames.Length)];
                string custNum = $"C-{random.Next(10000, 99999)}"; // Fixen med nummer!

                context.Customers.Add(new Customer
                {
                    FirstName = fName,
                    LastName = lName,
                    Email = $"{fName}.{lName}@test.com",
                    PhoneNumber = "070-123 45 67",
                    CustomerNumber = custNum
                });
            }
            context.SaveChanges();
            Console.WriteLine("✅ 50 Kunder skapade.");
        }

        private static void SeedProducts(AppDbContext context)
        {
            if (context.Products.Any()) return; // Redan klart

            Console.WriteLine("📦 Genererar Produkter...");
            
            // Vi lägger till en lista med IT-konsult-produkter
            context.Products.AddRange(
                new Product { Name = "Laptop High-End", Price = 25000m, Description = "För tunga kompileringar" },
                new Product { Name = "Ergonomisk Mus", Price = 899m, Description = "Räddar handleden" },
                new Product { Name = "4K Skärm 32-tum", Price = 4500m, Description = "Se all kod samtidigt" },
                new Product { Name = "Mekaniskt Tangentbord", Price = 1800m, Description = "Klickar högt" },
                new Product { Name = "Licens Visual Studio", Price = 5000m, Description = "Pro version" },
                new Product { Name = "Kaffemaskin Industrial", Price = 12000m, Description = "Utvecklarens bränsle" }
            );

            context.SaveChanges();
            Console.WriteLine("✅ Produkter skapade.");
        }
    }
}