using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class AuditLogController : Controller
    {
        private readonly IAuditLogService _auditLogService;

        // Constructor injecting the service responsible for AuditLog operations
        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService; // Storing the service instance
        }

        public async Task<IActionResult> Index()
        {
            var auditLogs = await _auditLogService.GetAllAuditLogsAsync();

            if (auditLogs == null)
            {
                return NotFound();
            }

            return View(auditLogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuditLogDto auditLogDto)
        {
            if (ModelState.IsValid)
            {
                await _auditLogService.CreateAuditLogAsync(auditLogDto);

                return RedirectToAction(nameof(Index));
            }

            return View(auditLogDto);
        }
    }
}
