namespace InventoryManagementSystem.Entities
{
    public class Supplier : BaseEntity
    {
        public string SupplierId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ValidPhoneNumber { get; set; }
        public string?Region { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
    }
}
