namespace BusinessCard_Project;
using Microsoft.EntityFrameworkCore;
using BusinessCard_Project.Models;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<UserViewModel> Users { get; set; }
    public DbSet<BusinessCardViewModel> BusinessCards { get; set; }
    public DbSet<CategoryViewModel> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserViewModel>()
        .HasKey(u => u.Id);

        modelBuilder.Entity<UserViewModel>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(256);

        modelBuilder.Entity<UserViewModel>()
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

        modelBuilder.Entity<CategoryViewModel>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<CategoryViewModel>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<UserViewModel>()
            .HasMany(u => u.Categories)
            .WithOne(c => c.Users)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
