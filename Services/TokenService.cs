using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using PolicyAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace PolicyAPI.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            
            var claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimTypes.Name, user.Username.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));

            foreach (var permission in user.Permissions)
            {
                claims.Add(new Claim(permission.Item1, permission.Item2));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}