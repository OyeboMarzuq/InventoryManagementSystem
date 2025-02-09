using InventoryManagementSystem.Entities;

namespace InventoryManagementSystem.Implementation.IRepository
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(string supplierId);
        Task<Supplier> AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(Supplier supplier);
    }
}
