using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;
using TaskManager.BusinessLogic.Interfaces;

namespace TaskManagerApi.Authorization
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {
        private readonly JwtOptions _options = options.Value;

        public string GenerateToken(UserEntity user)
        {
            Claim[] claims = [
                new(CustomClaims.UserId, user.Id.ToString()),
                new(CustomClaims.Role, "User"),
            ];

            var signinCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signinCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
