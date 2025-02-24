using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Implementation.Interface
{
    public interface ISupplierService
    {
        Task<BaseResponse<List<SupplierDto>>> GetAllSuppliersAsync();
        Task<SupplierDto> GetList(string supplierId);
        Task<BaseResponse<bool>> Create(SupplierDto supplierDto);
        Task<BaseResponse<bool>> UpdateSupplierAsync(string supplierId, SupplierDto supplierDto);
        Task<BaseResponse<bool>> DeleteSupplierAsync(string supplierId);
    }
}
