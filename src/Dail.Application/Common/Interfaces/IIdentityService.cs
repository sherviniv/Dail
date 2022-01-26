using Dail.Application.Common.Models.DataTransferObjects;
using Dail.Application.Common.Models.ViewModels;

namespace Dail.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);
    Task<UserDTO> GetUserAsync(string userId);
    Task<List<UserVM>> GetUsersAsync();
    Task<ServerResult<string>> CreateUserAsync(UserDTO model);
    Task<ServerResult<string>> UpdateUserAsync(UserDTO model);
    Task<ServerResult<string>> DeleteUserAsync(string userId);
    Task<ServerResult<string>> LoginUserAsync(LoginDTO model);
    Task<UserDTO> GetCurrentUserInfo();
    Task<ServerResult<string>> UpdateProfileAsync(UserDTO model);
}