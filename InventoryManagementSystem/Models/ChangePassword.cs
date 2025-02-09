using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class ChangePassword
    {
        [Required]
        public string? CurrentPassword { get; set; }

        [Required]
        public string? NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string? ConfirmNewPassword { get; set; }
    }
}
