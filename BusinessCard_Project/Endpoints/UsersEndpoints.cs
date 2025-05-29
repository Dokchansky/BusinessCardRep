using BusinessCard_Project.Contracts.Users;
using BusinessCard_Project.Models;
using BusinessCard_Project.Services;
using Microsoft.AspNetCore.Identity.Data;

namespace BusinessCard_Project.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        app.MapPost("login", Login);
        
        return app;
    }

    private static async Task<IResult> Register(RegisterUserRequest request,UserService userService)
    {
        await userService.Register(request.Email, request.Password); 
        return Results.Ok();
    }

    private static async Task<IResult> Login()
    {
        return Results.Ok();
    }
}