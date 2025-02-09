using InventoryManagementSystem.Enum;

namespace InventoryManagementSystem.Models
{
    public class SignUp
    {
        public string? FirstName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsActive { get; set; }
    }
}
