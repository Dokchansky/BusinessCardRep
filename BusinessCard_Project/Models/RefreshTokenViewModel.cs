namespace BusinessCard_Project.Models
{

    public class RefreshTokenViewModel
    {
        public int ID { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
        
        public virtual UserViewModel? Users { get; set; } 
    }
}