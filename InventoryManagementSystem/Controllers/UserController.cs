using InventoryManagementSystem.DTO;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.Interface;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Logout()
        //{
        //    await _userService.LogoutAsync();
        //    return RedirectToAction("Login", "User");
        //}

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var response = await _userService.UpdateUserAsync(user);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        //[HttpPost("Login")]
        //public async Task<IActionResult> Login([FromBody] Login model)
        //{
        //    var response = await _userService.LoginAsync(model);
        //    if (!response.Success)
        //        return Unauthorized(response);

        //    return Ok(response);
        //}

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUsersAsync();
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var response = await _userService.DeleteUserAsync(id);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
