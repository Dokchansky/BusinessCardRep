using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;
using BusinessCard_Project.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessCard_Project.Controllers
{
    public class GenerateTokenController
    {
        public string GenerateJwtToken(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlZsYWRpbWlyIFB1dGluIiwiaWF0IjoxNTE2MjM5MDIyfQ.P0EsD9VdltNahyNVGk9LIOMZu4hnsGAS7gJUxX7XLOE")); // Замените на ваш секретный ключ
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://myviscardrapp.com", 
                audience: "https://apimyviscardrapp.com", 
                claims: claims,
                expires: DateTime.Now.AddMinutes(15), 
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
        
        public void SaveRefreshToken(string email, string refreshToken)
        {
            var userId = 
                GetUserIdByEmail(email); 

            var token = new RefreshTokenViewModel
            {
                Token = refreshToken,
                Expiration = DateTime.UtcNow.AddDays(30), 
                UserId = userId
            };

            _context.RefreshTokens.Add(token);
            _context.SaveChanges();
        }
        
        private readonly Context _context;
        public GenerateTokenController(Context _context)
        {
            _context = _context;
        }
        public int GetUserIdByEmail(string email)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email);
            return user.Id; 
        }
    }
}
