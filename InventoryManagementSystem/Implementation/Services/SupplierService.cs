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
        public async Task<BaseResponse<List<SupplierDto>>> GetAllSuppliersAsync()
        {
            try
            {
                var suppliers = await _supplierRepository.GetAllSuppliersAsync();

                if (suppliers.Count > 0)
                {
                    var data = suppliers.Select(x => new SupplierDto
                    {
                        Name = x.Name,
                        Email = x.Email,
                        ValidPhoneNumber = x.ValidPhoneNumber,
                        Region = x.Region,
                        Address = x.Address,
                        FatherName = x.FatherName
                    }).ToList();

                    return new BaseResponse<List<SupplierDto>> { Message = "Data retrieved successfuly", IsSuccessful = true, Data = data };
                }

                return new BaseResponse<List<SupplierDto>> { Message = "No record", IsSuccessful = false, Data = new List<SupplierDto>() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<SupplierDto>> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = new List<SupplierDto>() };
            }
        }

        public async Task<SupplierDto> GetList(string supplierId)
        {
            var supplier = await _supplierRepository.GetList(supplierId);
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

        public async Task<BaseResponse<bool>> Create(SupplierDto supplierDto)
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

            var result = await _supplierRepository.Create(supplier);
            return new BaseResponse<bool>(true, "Supplier created successfully.");
        }

        public async Task<BaseResponse<bool>> UpdateSupplierAsync(string supplierId, SupplierDto supplierDto)
        {
            var supplier = await _supplierRepository.GetList(supplierId);
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
            var supplier = await _supplierRepository.GetList(supplierId);
            if (supplier == null)
                return new BaseResponse<bool>(false, "Supplier not found.");

            await _supplierRepository.DeleteAsync(supplier);
            return new BaseResponse<bool>(true, "Supplier deleted successfully.");
        }
    }
}
