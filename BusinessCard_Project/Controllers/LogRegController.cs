using BusinessCard_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BCrypt.Net;
using BusinessCard_Project.Controllers;

namespace BusinessCard_Project.Controllers
{
    /*[ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Context _context;
        private readonly GenerateTokenController _generateTokenController;
        
        
        public AuthController(IConfiguration configuration, Context context)
        {
            _configuration = configuration;
            _context = context;
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Требуется указать адрес электронной почты и пароль.");
            }


            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return BadRequest("Пользователь с таким адресом электронной почты существует!");
            }
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Регистрация прошла успешно!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserViewModel user, GenerateTokenController generateTokenController)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, existingUser.PasswordHash))
            {
                return Unauthorized("Неправильный логин или пароль!");
            }
            
            _generateTokenController.SaveRefreshToken(existingUser.Email, refreshToken: existingUser.PasswordHash);
            var token = generateTokenController.GenerateJwtToken(existingUser.Email);
            var refreshToken = generateTokenController.GenerateRefreshToken();
            
            return Ok(new TokenViewModel { AccessToken = token, RefreshToken = refreshToken });
            
        }
        
        
        
        
    }*/
    
}
