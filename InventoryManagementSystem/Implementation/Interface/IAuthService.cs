using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Implementation.Interface
{
    public interface IAuthService
    {
        Task<BaseResponse<User>> SignUp(SignUp model);
        Task<BaseResponse<User>> ChangePasswordAsync(string userId, ChangePassword model);
        Task<BaseResponse<User>> Login(Login model);
        Task LogoutAsync();
    }
}
