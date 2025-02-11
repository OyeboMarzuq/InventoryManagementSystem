using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Implementation.Interface
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(string productId);
        Task<BaseResponse<bool>> CreateProductAsync(ProductDto productDto);
        Task<BaseResponse<bool>> UpdateProductAsync(string productId, ProductDto productDto);
        Task<BaseResponse<bool>> DeleteProductAsync(string productId);
    }
}
