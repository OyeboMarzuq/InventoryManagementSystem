namespace InventoryManagementSystem.Entities
{
    public class DeliveredProduct : BaseEntity
    {
        public Supplier? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public Product? ProductId { get; set; }
        public Product? Product { get; set; }
        public int QuantityDelivered { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
