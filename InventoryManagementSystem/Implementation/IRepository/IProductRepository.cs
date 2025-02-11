using InventoryManagementSystem.Entities;

namespace InventoryManagementSystem.Implementation.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string productId);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
