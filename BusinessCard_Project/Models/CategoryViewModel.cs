using BusinessCard_Project.Entities;

namespace BusinessCard_Project.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual UserAccount UserAccounts { get; set; } 
        
    }
}
