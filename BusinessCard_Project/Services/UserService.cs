using BusinessCard_Project.Controllers;
using BusinessCard_Project.Models;

namespace BusinessCard_Project.Services;

public class UserService
{
    private readonly HomeController _controller;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(HomeController controller,IPasswordHasher passwordHasher)
    {
        _controller = controller;
        _passwordHasher = passwordHasher;
    }
    
    public async Task Register(string email, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);
        





    }
}