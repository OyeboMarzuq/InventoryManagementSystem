using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Implementation.Interface;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        // GET: Product/Details
        public async Task<IActionResult> Detail(string id)
        {
            if (id == string.Empty) return NotFound();

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

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
            if (!ModelState.IsValid) return View(productDto);

            var response = await _productService.CreateProductAsync(productDto);
            if (response.Success) return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, response.Message);
            return View(productDto);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == string.Empty) return NotFound();

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Product/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ProductDto productDto)
        {
            if (id != productDto.ProductId) return BadRequest();

            if (!ModelState.IsValid) return View(productDto);

            var response = await _productService.UpdateProductAsync(id, productDto);
            if (response.Success) return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, response.Message);
            return View(productDto);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == string.Empty) return NotFound();

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
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
