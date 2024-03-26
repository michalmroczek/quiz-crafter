using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using QuizCrafter.ModularComponents.Abstraction.Core;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Entities;
using System.Reflection;

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

            var discriminatorBuilder = modelBuilder.Entity<ModularComponentModel>().ToCollection("components")
                .HasDiscriminator<string>("Type");


            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            var directoryAssemblies = Directory.GetFiles(Path.GetDirectoryName(assemblyPath), "QuizCrafter.ModularComponents.*.Presentation.dll")
                                                .Select(Assembly.LoadFrom);
            foreach (var assembly in directoryAssemblies)
            {
                var componentTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ModularComponentModel)));

                foreach (var type in componentTypes)
                {
                    // modelBuilder.Entity(type);
                    discriminatorBuilder.HasValue(type, type.Name);
                }
            }


        }
    }
}
