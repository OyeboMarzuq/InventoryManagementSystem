using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Implementation.Interface;

namespace InventoryManagementSystem.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: Supplier
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return View(suppliers);
        }

        // GET: Supplier/Details/5
        public async Task<IActionResult> Detail(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();

            return View(supplier);
        }

        // GET: Supplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierDto supplierDto)
        {
            if (!ModelState.IsValid) return View(supplierDto);

            var response = await _supplierService.CreateSupplierAsync(supplierDto);
            if (response.Success) return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, response.Message);
            return View(supplierDto);
        }

        // GET: Supplier/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();

            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SupplierDto supplierDto)
        {
            if (id != supplierDto.SupplierId) return BadRequest();

            if (!ModelState.IsValid) return View(supplierDto);

            var response = await _supplierService.UpdateSupplierAsync(id, supplierDto);
            if (response.Success) return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, response.Message);
            return View(supplierDto);
        }

        // GET: Supplier/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();

            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var response = await _supplierService.DeleteSupplierAsync(id);
            if (response.Success) return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, response.Message);
            return RedirectToAction(nameof(Index));
        }
    }
}
