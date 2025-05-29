using System.ComponentModel.DataAnnotations;

namespace BusinessCard_Project.Contracts.Users;

public record RegisterUserRequest(
    [Required] string Email,
    [Required] string Password);
