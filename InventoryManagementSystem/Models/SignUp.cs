using System.ComponentModel.DataAnnotations;
using InventoryManagementSystem.Enum;

namespace InventoryManagementSystem.Models
{
    public class SignUp
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsActive { get; set; }
    }
}
