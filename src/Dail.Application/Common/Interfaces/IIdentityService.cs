using Dail.Application.Common.Models.DataTransferObjects;
using Dail.Application.Common.Models.ViewModels;

namespace Dail.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);
    Task<UserDTO> GetUserAsync(string userId);
    Task<List<UserVM>> GetUsersAsync();
    Task<string> CreateUserAsync(UserDTO model);
    Task<string> UpdateUserAsync(UserDTO model);
    Task<string> DeleteUserAsync(string userId);
    Task<string> LoginUserAsync(LoginDTO model);
}