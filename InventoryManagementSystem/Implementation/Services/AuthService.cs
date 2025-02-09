using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.Interface;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Implementation.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<BaseResponse<User>> SignUp(SignUp model)
        {
            try
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    UserRole = model.UserRole,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                return result.Succeeded
                    ? new BaseResponse<User> { Success = true, Message = "User created successfully.", Data = user }
                    : new BaseResponse<User> { Success = false, Message = string.Join(", ", result.Errors.Select(e => e.Description)) };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User> { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<BaseResponse<User>> ChangePasswordAsync(string userId, ChangePassword model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return new BaseResponse<User> { Success = false, Message = "User not found." };
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    return new BaseResponse<User> { Success = false, Message = string.Join(", ", result.Errors.Select(e => e.Description)) };
                }

                return new BaseResponse<User> { Success = true, Message = "Password changed successfully.", Data = user };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User> { Success = false, Message = $"Error changing password: {ex.Message}" };
            }
        }

        public async Task<BaseResponse<User>> Login(Login model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    return new BaseResponse<User> { Success = false, Message = "Invalid username or password." };
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
                return new BaseResponse<User> { Success = true, Message = "Login successful.", Data = user };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User> { Success = false, Message = $"Error logging in: {ex.Message}" };
            }
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
