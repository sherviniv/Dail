using Dail.Application.Common.Interfaces;
using System.Security.Claims;

namespace Dail.WebUI.Services;
public class CurrentUserService : ICurrentUserService
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    }
    public string? UserId { get; }

}