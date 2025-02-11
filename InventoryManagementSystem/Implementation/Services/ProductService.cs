using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.Interface;
using InventoryManagementSystem.Implementation.IRepository;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.ConvertAll(p => new ProductDto
            {
                ProductId = p.Id,
                ProductName = p.ProductName,
                Description = p.Description,
                Category = p.Category,
                QuantityInStock = p.QuantityInStock,
                QuantitySold = p.QuantitySold,
                QuantityDemand = p.QuantityDemand,
                QuantityDelivered = p.QuantityDelivered,
                Price = p.Price
            });
        }

        public async Task<ProductDto> GetProductByIdAsync(string productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return null;

            return new ProductDto
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Category = product.Category,
                QuantityInStock = product.QuantityInStock,
                QuantitySold = product.QuantitySold,
                QuantityDemand = product.QuantityDemand,
                QuantityDelivered = product.QuantityDelivered,
                Price = product.Price
            };
        }

        public async Task<BaseResponse<bool>> CreateProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                Category = productDto.Category,
                QuantityInStock = productDto.QuantityInStock,
                QuantitySold = productDto.QuantitySold,
                QuantityDemand = productDto.QuantityDemand,
                QuantityDelivered = productDto.QuantityDelivered,
                Price = productDto.Price
            };

            await _productRepository.AddAsync(product);
            return new BaseResponse<bool> { Success = true, Message = "Product created successfully." };
        }

        public async Task<BaseResponse<bool>> UpdateProductAsync(string productId, ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                return new BaseResponse<bool> { Success = false, Message = "Product not found." };

            product.ProductName = productDto.ProductName;
            product.Description = productDto.Description;
            product.Category = productDto.Category;
            product.QuantityInStock = productDto.QuantityInStock;
            product.QuantitySold = productDto.QuantitySold;
            product.QuantityDemand = productDto.QuantityDemand;
            product.QuantityDelivered = productDto.QuantityDelivered;
            product.Price = productDto.Price;

            await _productRepository.UpdateAsync(product);
            return new BaseResponse<bool> { Success = true, Message = "Product updated successfully." };
        }

        public async Task<BaseResponse<bool>> DeleteProductAsync(string productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                return new BaseResponse<bool> { Success = false, Message = "Product not found." };

            await _productRepository.DeleteAsync(product);
            return new BaseResponse<bool> { Success = true, Message = "Product deleted successfully." };
        }
    }
}
