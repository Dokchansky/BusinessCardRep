namespace BusinessCard_Project.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual UserViewModel? Users { get; set; } 
        public virtual ICollection<BusinessCardViewModel> BusinessCards { get; set; } = new List<BusinessCardViewModel>();
    }
}
