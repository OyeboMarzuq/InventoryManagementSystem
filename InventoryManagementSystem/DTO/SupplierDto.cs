using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.DTO
{
    public class SupplierDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "ValidPhoneNumber is required.")]
        public string ValidPhoneNumber { get; set; }
        [Required(ErrorMessage = "Region is required.")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "FatherName is required.")]
        public string FatherName { get; set; }
        public string SupplierId { get; set; }
    }
}
