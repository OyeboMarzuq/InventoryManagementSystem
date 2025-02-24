using InventoryManagementSystem.Implementation.Interface;
using Azure.Core;
using InventoryManagementSystem.Implementation.Services;
using InventoryManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.DTO;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product/Details
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(string Id)
        {
            var product = await _productService.GetAllProductsAsync(Id);
            if (product == null)
            {
                return NotFound(); // Handle missing product
            }
            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                // Save the product (assuming a service is used for data handling)
                await _productService.CreateProductAsync(productDto);

                // Redirect to the Product Details page after successful creation
                return RedirectToAction("Details", new { id = productDto.Id });
            }

            // If model validation fails, return to the Create view
            return View(productDto);
        }


        // GET: Product/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == string.Empty) return NotFound();

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Product/Edit
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ProductDto productDto)
        {
            if (id != productDto.Id) return BadRequest();

            if (!ModelState.IsValid) return View(productDto);

            var response = await _productService.UpdateProductAsync(id, productDto);
            if (response.Success) return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, response.Message);
            return View(productDto);
        }

        // GET: Product/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == string.Empty) return NotFound();

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var response = await _productService.DeleteProductAsync(id);
            if (response.Success) return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, response.Message);
            return RedirectToAction(nameof(Index));
        }
    }
}
