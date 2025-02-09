using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.Interface;
using InventoryManagementSystem.Implementation.IRepository;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Implementation.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<List<SupplierDto>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            return suppliers.ConvertAll(s => new SupplierDto
            {
                SupplierId = s.Id.ToString(),
                Name = s.Name,
                Email = s.Email,
                ValidPhoneNumber = s.ValidPhoneNumber,
                Region = s.Region,
                Address = s.Address,
                FatherName = s.FatherName
            });
        }

        public async Task<SupplierDto> GetSupplierByIdAsync(string supplierId)
        {
            var supplier = await _supplierRepository.GetByIdAsync(supplierId);
            if (supplier == null) return null;

            return new SupplierDto
            {
                SupplierId = supplier.Id.ToString(),
                Name = supplier.Name,
                Email = supplier.Email,
                ValidPhoneNumber = supplier.ValidPhoneNumber,
                Region = supplier.Region,
                Address = supplier.Address,
                FatherName = supplier.FatherName
            };
        }

        public async Task<BaseResponse<bool>> CreateSupplierAsync(SupplierDto supplierDto)
        {
            var supplier = new Supplier
            {
                Name = supplierDto.Name,
                Email = supplierDto.Email,
                ValidPhoneNumber = supplierDto.ValidPhoneNumber,
                Region = supplierDto.Region,
                Address = supplierDto.Address,
                FatherName = supplierDto.FatherName
            };

            var result = await _supplierRepository.AddAsync(supplier);
            return new BaseResponse<bool>(true, "Supplier created successfully.");
        }

        public async Task<BaseResponse<bool>> UpdateSupplierAsync(string supplierId, SupplierDto supplierDto)
        {
            var supplier = await _supplierRepository.GetByIdAsync(supplierId);
            if (supplier == null)
                return new BaseResponse<bool>(false, "Supplier not found.");

            supplier.Name = supplierDto.Name;
            supplier.Email = supplierDto.Email;
            supplier.ValidPhoneNumber = supplierDto.ValidPhoneNumber;
            supplier.Region = supplierDto.Region;
            supplier.Address = supplierDto.Address;
            supplier.FatherName = supplierDto.FatherName;

            await _supplierRepository.UpdateAsync(supplier);
            return new BaseResponse<bool>(true, "Supplier updated successfully.");
        }

        public async Task<BaseResponse<bool>> DeleteSupplierAsync(string supplierId)
        {
            var supplier = await _supplierRepository.GetByIdAsync(supplierId);
            if (supplier == null)
                return new BaseResponse<bool>(false, "Supplier not found.");

            await _supplierRepository.DeleteAsync(supplier);
            return new BaseResponse<bool>(true, "Supplier deleted successfully.");
        }
    }
}
