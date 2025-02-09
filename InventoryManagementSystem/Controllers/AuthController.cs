using InventoryManagementSystem.Implementation.Interface;
using InventoryManagementSystem.Implementation.Services;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.Login(model);
                if (result.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, result.Message);
            }
            return View(model);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUp model)
        {
            if (!ModelState.IsValid)
            {
                // Return the same view with validation errors
                return View(model);
            }

            var response = await _authService.SignUp(model);
            if (!response.Success)
            {
                // Add the error message to the ModelState
                ModelState.AddModelError(string.Empty, response.Message);
                return View(model);
            }

            // Redirect to the login page or dashboard upon successful signup
            return RedirectToAction("Login", "Layout");
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPut("ChangePassword/{userId}")]
        public async Task<IActionResult> ChangePassword(string userId, [FromBody] ChangePassword model)
        {
            var response = await _authService.ChangePasswordAsync(userId, model);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
