using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using QuizCrafter.ModularComponents.Abstraction.ComponentLoader;
using QuizCrafter.ModularComponents.Abstraction.Core;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Entities;

namespace QuizCrafter.Modules.Quizzes.Infrastructure.EF
{
    public class QuizzesDbContext : DbContext
    {
        public DbSet<QuizItem>  Quizzes { get; init; }

       public DbSet<ModularComponentModel> ModularComponents { get; init; }

       public QuizzesDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuizItem>().ToCollection("quizzes");

            modelBuilder.Entity<ModularComponentModel>().ToCollection("components")
                .HasDiscriminator<string>("Type");
                
        }
    }
}
