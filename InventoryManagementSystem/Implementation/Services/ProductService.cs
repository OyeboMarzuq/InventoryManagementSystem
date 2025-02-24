using InventoryManagementSystem.Context;
using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.Interface;
using InventoryManagementSystem.Implementation.IRepository;
using InventoryManagementSystem.Implementation.Repository;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ApplicationDbContext _dbContext;

        public ProductService(IProductRepository productRepository, ApplicationDbContext dbContext)
        {
            _productRepository = productRepository;
            _dbContext = dbContext;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync(string Id)
        {
            var products = await _productRepository.GetAllProductsAsync(Id);
            return products.ConvertAll(p => new ProductDto
            {
                Id = p.Id,
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

        //public async Task<ProductDto> GetProductByIdAsync(string productId)
        //{
        //    var product = await _productRepository.GetByIdAsync(productId);
        //    if (product == null) return null;

        //    return new ProductDto
        //    {
        //        Id = product.Id,
        //        ProductName = product.ProductName,
        //        Description = product.Description,
        //        Category = product.Category,
        //        QuantityInStock = product.QuantityInStock,
        //        QuantitySold = product.QuantitySold,
        //        QuantityDemand = product.QuantityDemand,
        //        QuantityDelivered = product.QuantityDelivered,
        //        Price = product.Price
        //    };
        //}

        public async Task<ProductDto> GetProductByIdAsync(string id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
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
            if (productDto == null)
            {
                return new BaseResponse<bool>
                {
                    Message = "Invalid product data",
                    IsSuccessful = false,
                    Data = false
                };
            }

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

            try
            {
                await _dbContext.Products.AddAsync(product);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "Product created successfully", IsSuccessful = true, Data = true };
                }

                return new BaseResponse<bool> { Message = "Product creation failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"An error occurred: {ex.Message}", IsSuccessful = false, Data = false };
            }
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
