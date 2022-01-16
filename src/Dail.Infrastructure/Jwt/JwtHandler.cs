using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Models;
using Dail.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dail.Infrastructure.Jwt
{
    public class JwtHandler : IJwtHandler
    {
        private readonly AppSettings _appSettings;

        public JwtHandler(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(ApplicationUser user, List<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Jwt.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                       new Claim(ClaimTypes.NameIdentifier,user.Id),
                       new Claim(ClaimTypes.Name,user.UserName),
                }),
                Issuer = _appSettings.Jwt.Issuer,
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.Jwt.ExpiryMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var claimRoles = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToArray();
            tokenDescriptor.Subject.AddClaims(claimRoles);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
