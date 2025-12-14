using ERPCore.ConsoleUI.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("----- TESTAR KOPPLING MOT AZURE (VERSION 2) -----");

try
{
    using (var context = new AppDbContext())
    {
        // Denna rad kastar ett fel om den misslyckas, så vi får veta varför!
        context.Database.OpenConnection(); 
        
        Console.WriteLine("✅ SUCCÉ! Du är inloggad och uppkopplad.");
        context.Database.CloseConnection();
    }
}
catch (Exception ex)
{
    Console.WriteLine("❌ KRASCH! Här är det exakta felet:");
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine(ex.Message);
    
    // Ibland ligger det verkliga felet ett steg djupare
    if (ex.InnerException != null)
    {
        Console.WriteLine();
        Console.WriteLine("DETALJERAT FEL:");
        Console.WriteLine(ex.InnerException.Message);
    }
    Console.WriteLine("--------------------------------------------------");
}