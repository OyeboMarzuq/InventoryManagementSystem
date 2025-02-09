using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Implementation.Interface
{
    public interface ISupplierService
    {
        Task<List<SupplierDto>> GetAllSuppliersAsync();
        Task<SupplierDto> GetSupplierByIdAsync(string supplierId);
        Task<BaseResponse<bool>> CreateSupplierAsync(SupplierDto supplierDto);
        Task<BaseResponse<bool>> UpdateSupplierAsync(string supplierId, SupplierDto supplierDto);
        Task<BaseResponse<bool>> DeleteSupplierAsync(string supplierId);
    }
}
