using InventoryManagementSystem.Context;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.IRepository;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Implementation.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync(string Id)
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        //public async Task<Product> GetByIdAsync(string productId)
        //{
        //    return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        //}

        public async Task<Product> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
