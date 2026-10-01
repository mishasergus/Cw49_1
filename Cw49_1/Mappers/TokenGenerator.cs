using Cw49_1.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Cw49_1.Mappers
{
    public static class TokenGenerator
    {
        public static string? GetToken(UserDto user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("your_secret_key_here_looooooooooooooooong_key"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
