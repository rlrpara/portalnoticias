using Microsoft.IdentityModel.Tokens;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Infra.CrossCutting.Auth.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortalNoticias.Infra.CrossCutting.Auth.Services
{
    public static class TokenService
    {
        public static string GenerateToken(Usuario usuario)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Settings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, usuario.Nome),
                        new Claim(ClaimTypes.Email, usuario.Email),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Codigo.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch
            {
                return default(dynamic);
            }
        }
    }
}
