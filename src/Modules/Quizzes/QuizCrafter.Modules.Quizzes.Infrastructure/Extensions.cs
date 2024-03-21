using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Repositories;
using QuizCrafter.Modules.Quizzes.Infrastructure.EF;
using QuizCrafter.Modules.Quizzes.Infrastructure.EF.Repositories;

namespace QuizCrafter.Modules.Quizzes.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<QuizzesDbContext>(options =>
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("QuizCrafter");
                options.UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName);
            });

            services.AddScoped<IQuizRepository, QuizRepository>();

            return services;
        }
    }
}



