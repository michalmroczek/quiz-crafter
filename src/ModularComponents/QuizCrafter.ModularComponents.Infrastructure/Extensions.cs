using Microsoft.Extensions.DependencyInjection;
using QuizCrafter.ModularComponents.Abstraction.ComponentLoader;
using QuizCrafter.ModularComponents.Infrastructure.ComponentLoader;

namespace QuizCrafter.ModularComponents.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    => services
            .AddSingleton<IModularComponentLoader, ListedModularComponentLoader>()
            .AddSingleton<IModularComponentCollection, ModularComponentCollection>();
    }
}
