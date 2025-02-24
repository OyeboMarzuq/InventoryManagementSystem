using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.DTO
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Quantity In Stock is required.")]
        public int QuantityInStock { get; set; }

        [Required(ErrorMessage = "Quantity Demand is required.")]
        public int QuantityDemand { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public int QuantitySold { get; set; }
        public int QuantityDelivered { get; set; }
    }
}
