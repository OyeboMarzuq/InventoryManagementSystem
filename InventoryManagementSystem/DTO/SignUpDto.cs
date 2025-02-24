using InventoryManagementSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.DTO
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "User Role is required.")]
        public UserRole UserRole { get; set; }
    }
}
