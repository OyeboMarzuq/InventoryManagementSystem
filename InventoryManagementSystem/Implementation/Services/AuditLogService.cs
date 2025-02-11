using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.Interface;
using InventoryManagementSystem.Implementation.IRepository;

namespace InventoryManagementSystem.Implementation.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        // Constructor injecting the repository to interact with the data source
        public AuditLogService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<List<AuditLog>> GetAllAuditLogsAsync()
        {
            return await _auditLogRepository.GetAllAsync();
        }

        // Creates a new audit log asynchronously
        public async Task CreateAuditLogAsync(AuditLogDto auditLogDto)
        {
            // Convert DTO to entity (you can also map with AutoMapper if needed)
            var auditLog = new AuditLog
            {
               // Id = Guid.NewGuid(),
                ActionPerformed = auditLogDto.ActionPerformed,
                PerformedBy = auditLogDto.PerformedBy,
                Timestamp = DateTime.UtcNow,
                Details = auditLogDto.Details
            };

            await _auditLogRepository.AddAsync(auditLog);
        }
    }
}
