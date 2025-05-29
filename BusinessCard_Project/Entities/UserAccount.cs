using System.ComponentModel.DataAnnotations;
using BusinessCard_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessCard_Project.Entities
{
    [Index(nameof(Email), IsUnique = true)]

    public class UserAccount
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Требуется пароль")]
        [MinLength(8, ErrorMessage = "Минимальный размер пароля 8 символов")]
        public string Password { get; set; }
        
        public string PasswordHash { get; set; }
        

        public virtual ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}