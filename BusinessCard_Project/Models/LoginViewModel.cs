using System.ComponentModel.DataAnnotations;

namespace BusinessCard_Project.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Требуется Email")]
    [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
        ErrorMessage = "Пожалуйста, введите корректный Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Требуется пароль")]
    [MinLength(8, ErrorMessage = "Минимальный размер пароля 8 символов")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}