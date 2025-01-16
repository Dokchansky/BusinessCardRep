namespace BusinessCard_Project.Models
{
    public class BusinessCardViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Position { get; set; }
        public string? Company { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? SocialMedia { get; set; } 
        public byte[]? Logo { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual CategoryViewModel? Categories { get; set; }
        public virtual UserViewModel? Users { get;  set; }
    }

    
}
