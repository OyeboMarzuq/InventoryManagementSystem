using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Entities;

namespace InventoryManagementSystem.Implementation.Interface
{
    public interface IAuditLogService
    {
        Task<List<AuditLog>> GetAllAuditLogsAsync();
        Task CreateAuditLogAsync(AuditLogDto auditLogDto);
    }
}
