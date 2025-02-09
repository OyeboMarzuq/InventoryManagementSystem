using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Implementation.Interface;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagementSystem.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<BaseResponse<User>> UpdateUserAsync(User user)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(user.Id);
                if (User == null)
                {
                    return new BaseResponse<User> { Success = false, Message = "User not found." };
                }

                User.FirstName = user.FirstName;
                User.PhoneNumber = user.PhoneNumber;
                User.Address = user.Address;
                User.Gender = user.Gender;
                User.DateOfBirth = user.DateOfBirth;
                User.UserRole = user.UserRole;
                User.IsActive = user.IsActive;
                User.DateUpdated = DateTime.UtcNow;

                var result = await _userManager.UpdateAsync(User);

                if (!result.Succeeded)
                {
                    return new BaseResponse<User> { Success = false, Message = string.Join(", ", result.Errors.Select(e => e.Description)) };
                }

                return new BaseResponse<User> { Success = true, Message = "User updated successfully.", Data = User };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User> { Success = false, Message = $"Error updating user: {ex.Message}" };
            }
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<BaseResponse<User>> GetUserByIdAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return new BaseResponse<User> { Success = false, Message = "User not found." };
                }

                return new BaseResponse<User> { Success = true, Message = "User retrieved successfully.", Data = user };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User> { Success = false, Message = $"Error retrieving user: {ex.Message}" };
            }
        }

        public async Task<BaseResponse<List<User>>> GetAllUsersAsync()
        {
            try
            {
                var users = _userManager.Users.ToList();
                return new BaseResponse<List<User>> { Success = true, Message = "Users retrieved successfully.", Data = users };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<User>> { Success = false, Message = $"Error retrieving users: {ex.Message}" };
            }
        }

        public async Task<BaseResponse<bool>> DeleteUserAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return new BaseResponse<bool> { Success = false, Message = "User not found." };
                }

                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    return new BaseResponse<bool> { Success = false, Message = string.Join(", ", result.Errors.Select(e => e.Description)) };
                }

                return new BaseResponse<bool> { Success = true, Message = "User deleted successfully.", Data = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Success = false, Message = $"Error deleting user: {ex.Message}" };
            }
        }
    }
}
