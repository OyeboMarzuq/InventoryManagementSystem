namespace InventoryManagementSystem.Entities
{
    public class AuditLog : BaseEntity
    {
        public string? ActionPerformed { get; set; }
        public string? PerformedBy { get; set; } 
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? Details { get; set; }
    }

}
