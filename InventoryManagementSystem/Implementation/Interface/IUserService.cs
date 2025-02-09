using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Implementation.Interface
{
    public interface IUserService
    {
        Task<BaseResponse<User>> UpdateUserAsync(User user);
        Task<BaseResponse<User>> GetUserByIdAsync(string id);
        Task<BaseResponse<List<User>>> GetAllUsersAsync();
        Task<BaseResponse<bool>> DeleteUserAsync(string id);
    }
}
