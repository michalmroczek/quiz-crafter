using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Entities;

namespace QuizCrafter.Modules.Quizzes.Infrastructure.EF
{
    public class QuizzesDbContext : DbContext
    {
        public DbSet<QuizItem>  Quizzes { get; init; }

       public QuizzesDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuizItem>().ToCollection("quizzes");
        }
    }
}
