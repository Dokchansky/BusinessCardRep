using BusinessCard_Project.Entities;

namespace BusinessCard_Project;
using Microsoft.EntityFrameworkCore;
using BusinessCard_Project.Models;
public class Context : DbContext
{
    protected readonly IConfiguration Configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }
    
    public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<BusinessCardViewModel> BusinessCards { get; set; } = null!;
    public DbSet<CategoryViewModel> Categories { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserAccount>()
        .HasKey(u => u.Id);

        modelBuilder.Entity<UserAccount>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);

        modelBuilder.Entity<UserAccount>()
            .Property(u => u.PasswordHash)
            .IsRequired();

        modelBuilder.Entity<BusinessCardViewModel>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<BusinessCardViewModel>()
            .Property(b => b.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<BusinessCardViewModel>()
            .Property(b => b.LastName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<BusinessCardViewModel>()
            .Property(b => b.Position)
            .HasMaxLength(100);

        modelBuilder.Entity<BusinessCardViewModel>()
            .Property(b => b.Company)
            .HasMaxLength(100);

        modelBuilder.Entity<BusinessCardViewModel>()
            .Property(b => b.Phone)
            .HasMaxLength(15);

        modelBuilder.Entity<BusinessCardViewModel>()
            .Property(b => b.Email)
            .HasMaxLength(256);

        modelBuilder.Entity<BusinessCardViewModel>()
            .Property(b => b.Website)
            .HasMaxLength(256);
        
        modelBuilder.Entity<BusinessCardViewModel>()
            .Property(b => b.SocialMedia)
            .HasMaxLength(256);

        modelBuilder.Entity<CategoryViewModel>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<CategoryViewModel>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<UserAccount>()
            .HasMany(u => u.Categories)
            .WithOne(c => c.UserAccounts)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        

        

        
    }
}
