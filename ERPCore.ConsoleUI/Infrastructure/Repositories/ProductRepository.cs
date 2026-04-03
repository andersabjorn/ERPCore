using ERPCore.ConsoleUI.Models;
using ERPCore.ConsoleUI.Data;
using ERPCore.ConsoleUI.Interfaces;

namespace ERPCore.ConsoleUI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Product> GetAll()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to retrieve products.", ex);
            }
        }

        public Product GetById(int id)
        {
            try
            {
                return _context.Products.Find(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to retrieve product with id {id}.", ex);
            }
        }

        public void Add(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to save product '{product.Name}'.", ex);
            }
        }
    }
}
