
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pawsonality.API.Models;

namespace Pawsonality.API.DAO;

public class AppDbContext : IdentityDbContext<IdentityUser>
{

    public AppDbContext() { }

    public AppDbContext(DbContextOptions options) : base(options) { }

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

        modelBuilder.Entity<Question>().HasData(
       new Question { QuestionID = 1, QuestionText = "How do you prefer to spend your weekend?" },
       new Question { QuestionID = 2, QuestionText = "What's your approach to solving problems?" },
       new Question { QuestionID = 3, QuestionText = "How do you feel about meeting new people?" },
       new Question { QuestionID = 4, QuestionText = "What type of environment do you thrive in?" },
       new Question { QuestionID = 5, QuestionText = "How do you handle stressful situations?" },
       new Question { QuestionID = 6, QuestionText = "What's your idea of a perfect vacation?" }
   );

        // Seed Answers
        modelBuilder.Entity<Answer>().HasData(
            // Question 1 Answers
            new Answer { AnswerID = 1, QuestionID = 1, AnswerText = "Attending a social event or party", AnswerType = "Dog" },
            new Answer { AnswerID = 2, QuestionID = 1, AnswerText = "Curled up with a good book or movie at home", AnswerType = "Cat" },
            new Answer { AnswerID = 3, QuestionID = 1, AnswerText = "Exploring the outdoors or going on a hike", AnswerType = "Bird" },
            new Answer { AnswerID = 4, QuestionID = 1, AnswerText = "Observing and analyzing something quietly, perhaps in a cozy corner", AnswerType = "Snake" },

            // Question 2 Answers
            new Answer { AnswerID = 5, QuestionID = 2, AnswerText = "Gather your friends and brainstorm together", AnswerType = "Dog" },
            new Answer { AnswerID = 6, QuestionID = 2, AnswerText = "Think it through on your own and come up with a creative solution", AnswerType = "Cat" },
            new Answer { AnswerID = 7, QuestionID = 2, AnswerText = "Look at the problem from different perspectives and find a high-level view", AnswerType = "Bird" },
            new Answer { AnswerID = 8, QuestionID = 2, AnswerText = "Study the issue deeply and methodically until you find the best solution", AnswerType = "Snake" },

            // Question 3 Answers
            new Answer { AnswerID = 9, QuestionID = 3, AnswerText = "Excited! You love making new friends", AnswerType = "Dog" },
            new Answer { AnswerID = 10, QuestionID = 3, AnswerText = "Cautious at first, but you warm up once you feel comfortable", AnswerType = "Cat" },
            new Answer { AnswerID = 11, QuestionID = 3, AnswerText = "Interested, but you prefer to keep interactions light and breezy", AnswerType = "Bird" },
            new Answer { AnswerID = 12, QuestionID = 3, AnswerText = "Selective; you prefer deep, meaningful connections over casual ones", AnswerType = "Snake" },

            // Question 4 Answers
            new Answer { AnswerID = 13, QuestionID = 4, AnswerText = "A bustling, lively place full of energy and activity", AnswerType = "Dog" },
            new Answer { AnswerID = 14, QuestionID = 4, AnswerText = "A calm, quiet space where you can relax and be yourself", AnswerType = "Cat" },
            new Answer { AnswerID = 15, QuestionID = 4, AnswerText = "An open, airy space with plenty of room to roam", AnswerType = "Bird" },
            new Answer { AnswerID = 16, QuestionID = 4, AnswerText = "A secluded, undisturbed spot where you can focus and observe", AnswerType = "Snake" },

            // Question 5 Answers
            new Answer { AnswerID = 17, QuestionID = 5, AnswerText = "Lean on your friends or loved ones for support", AnswerType = "Dog" },
            new Answer { AnswerID = 18, QuestionID = 5, AnswerText = "Retreat to your personal space to recharge and reflect", AnswerType = "Cat" },
            new Answer { AnswerID = 19, QuestionID = 5, AnswerText = "Rise above the situation and look at it from a different perspective", AnswerType = "Bird" },
            new Answer { AnswerID = 20, QuestionID = 5, AnswerText = "Stay calm and composed, quietly analyzing your next move", AnswerType = "Snake" },
            // Question 6 Answers
            new Answer { AnswerID = 21, QuestionID = 6, AnswerText = "A group trip with friends to a fun destination", AnswerType = "Dog" },
            new Answer { AnswerID = 22, QuestionID = 6, AnswerText = "A solo retreat to a peaceful and cozy spot", AnswerType = "Cat" },
            new Answer { AnswerID = 23, QuestionID = 6, AnswerText = "An adventure exploring new places and enjoying nature", AnswerType = "Bird" },
            new Answer { AnswerID = 24, QuestionID = 6, AnswerText = "A quiet escape where you can immerse yourself in your surroundings", AnswerType = "Snake" }
        );


    }
}