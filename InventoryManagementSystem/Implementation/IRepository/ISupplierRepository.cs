using InventoryManagementSystem.Entities;

namespace InventoryManagementSystem.Implementation.IRepository
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> GetList(string supplierId);
        Task<Supplier> Create(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(Supplier supplier);
    }
}
