using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.DTO
{
    public class AuditLogDto
    {
        [Required(ErrorMessage = "Action Performed is required.")]
        public string? ActionPerformed { get; set; }

        [Required(ErrorMessage = "Performed By is required.")]
        public string? PerformedBy { get; set; }

        [Required(ErrorMessage = "Timestamp is required.")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public string? Details { get; set; }  // Optional field
    }
}
