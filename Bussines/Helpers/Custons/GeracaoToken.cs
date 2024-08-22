
using Businnes.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Custom_Identity.Helpers.Custons
{
    public static class TokenService
    {
        public static string GenerateToken(UsuarioVm usuario, IConfiguration _configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Token:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new(ClaimTypes.Name, usuario.UsuarioId.ToString()),
                        new(ClaimTypes.Name, usuario.NomeCompleto),
                        new(ClaimTypes.Name, usuario.Email),
                        new(ClaimTypes.Role, UsuarioVm.GetRoleDisplayName(usuario.Role)),
                }),
                Issuer = _configuration["Token:Issuer"],
                Audience = _configuration["Token:Audience"],
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
