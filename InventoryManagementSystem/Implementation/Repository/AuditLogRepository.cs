using InventoryManagementSystem.Context;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.IRepository;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Implementation.Repository
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly ApplicationDbContext _context;

        public AuditLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuditLog>> GetAllAsync()
        {
            return await _context.AuditLogs.ToListAsync();
        }

        // Add a new audit log
        public async Task AddAsync(AuditLog auditLog)
        {
            await _context.AuditLogs.AddAsync(auditLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AuditLog auditLog)
        {
            _context.AuditLogs.Update(auditLog);
            await _context.SaveChangesAsync();
        }
    }
}
