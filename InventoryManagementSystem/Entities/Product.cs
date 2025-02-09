namespace InventoryManagementSystem.Entities
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int QuantityInStock { get; set; }
        public int QuantitySold { get; set; }
        public int QuantityDemand { get; set; }
        public int QuantityDelivered { get; set; }
        public decimal Price { get; set; }
    }
}
