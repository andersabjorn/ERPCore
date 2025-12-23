using ERPCore.ConsoleUI.Models;
using ERPCore.ConsoleUI.Data;
using ERPCore.ConsoleUI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERPCore.ConsoleUI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}