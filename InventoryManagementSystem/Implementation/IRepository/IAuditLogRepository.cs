using InventoryManagementSystem.Entities;

namespace InventoryManagementSystem.Implementation.IRepository
{
    public interface IAuditLogRepository
    {
        Task<List<AuditLog>> GetAllAsync();
        Task AddAsync(AuditLog auditLog);
        Task UpdateAsync(AuditLog auditLog);
    }
}
