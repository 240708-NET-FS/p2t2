
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public class AppDbContext : IdentityDbContext<IdentityUser> {

    public AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options ){ }

    public DbSet<Question> Question { get; set; }
    public DbSet<Answer> Answer { get; set; }
    public DbSet<Result> Result { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answer)
                .HasForeignKey(a => a.QuestionID);
            
            modelBuilder.Entity<Result>()
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Question>()
            .HasIndex(q => q.QuestionText)
            .IsUnique();

        
    }
}