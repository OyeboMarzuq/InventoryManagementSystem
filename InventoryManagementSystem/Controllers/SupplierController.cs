using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Implementation.Interface;
using System.Threading.Tasks;
using Azure.Core;
using InventoryManagementSystem.Implementation.Services;

namespace InventoryManagementSystem.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: All Suppliers
        public async Task<IActionResult> SupplierDetails()
        {
            var result = await _supplierService.GetAllSuppliersAsync();
            return View(result.Data);
        }

        // GET: Create Supplier View
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Supplier
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
            {
                return View(supplierDto);
            }

            var result = await _supplierService.Create(supplierDto);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Books");
            }
            return RedirectToAction("CreateBook");
        }

        ////// GET: Supplier Details
        ////public async Task<IActionResult> SupplierDetails(string id)
        ////{
        ////    var supplier = await _supplierService.GetList(id);
        ////    if (supplier == null)
        ////    {
        ////        return NotFound();
        ////    }
        ////    return View(supplier);
        ////}

        // GET: Edit Supplier View
        public async Task<IActionResult> Edit(string id)
        {
            var supplier = await _supplierService.GetList(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Edit Supplier
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
            {
                return View(supplierDto);
            }

            var response = await _supplierService.UpdateSupplierAsync(id, supplierDto);

            if (response.Status)
            {
                return RedirectToAction("Details", new { id });
            }

            ModelState.AddModelError("", response.Message);
            return View(supplierDto);
        }

        // GET: Delete Supplier
        public async Task<IActionResult> Delete(string id)
        {
            var supplier = await _supplierService.GetList(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Confirm Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var response = await _supplierService.DeleteSupplierAsync(id);
            if (response.Status)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", response.Message);
            return View();
        }
    }
}
