namespace BusinessCard_Project.Models
{
    public partial class UserViewModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<BusinessCardViewModel> BusinessCards { get; set; } = new List<BusinessCardViewModel>();
        public virtual ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
