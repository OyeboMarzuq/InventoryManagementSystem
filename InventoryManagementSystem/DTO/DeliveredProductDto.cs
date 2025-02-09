using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.DTO
{
    public class DeliveredProductDto
    {
        [Required(ErrorMessage = "Supplier is required.")]
        public Guid SupplierId { get; set; }

        [Required(ErrorMessage = "Product is required.")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Quantity Delivered is required.")]
        public int QuantityDelivered { get; set; }

        [Required(ErrorMessage = "Delivery Date is required.")]
        public DateTime DeliveryDate { get; set; }
    }
}
