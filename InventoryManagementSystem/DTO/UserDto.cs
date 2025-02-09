using System.ComponentModel.DataAnnotations;
using InventoryManagementSystem.Enum;

namespace InventoryManagementSystem.DTO
{
    public class UserDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "User role is required.")]
        public UserRole UserRole { get; set; }

        [Required(ErrorMessage = "Active status is required.")]
        public bool IsActive { get; set; }
        public Guid Id { get; set; }

    }
}
