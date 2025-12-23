using ERPCore.ConsoleUI.Models;

namespace ERPCore.ConsoleUI.Interfaces
{
    public interface IProductRepository
    {
      
        List<Product> GetAll();

        Product GetById(int id);
        void Add(Product product);
    }
}