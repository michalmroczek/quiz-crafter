using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using QuizCrafter.Modules.Quizzes.Domain.Quizzes.Repositories;
using QuizCrafter.Modules.Quizzes.Infrastructure.EF;
using QuizCrafter.Modules.Quizzes.Infrastructure.EF.Repositories;

namespace QuizCrafter.Modules.Quizzes.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MongoDb");
            string databaseName = configuration["MongoDbSettings:DatabaseName"];

            services.AddDbContext<QuizzesDbContext>(options  =>
            {
               
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                options.UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName);
            });

            services.AddScoped<IQuizRepository, QuizRepository>();

            return services;
        }
    }
}



