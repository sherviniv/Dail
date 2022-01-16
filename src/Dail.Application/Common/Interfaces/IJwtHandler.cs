using Dail.Domain.Entities;

namespace Dail.Application.Common.Interfaces;
public interface IJwtHandler
{
    string GenerateToken(ApplicationUser user, List<string> roles);
}