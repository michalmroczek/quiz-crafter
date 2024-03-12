using Microsoft.AspNetCore.Components.WebAssembly.Services;
using QuizCrafter.ModularComponents.Abstraction.ComponentLoader;
using QuizCrafter.ModularComponents.Abstraction.Core;
using System.Reflection;


namespace QuizCrafter.ModularComponents.Infrastructure.ComponentLoader
{
    public class ListedModularComponentLoader(LazyAssemblyLoader lazyAssemblyLoader) : IModularComponentLoader
    {

        private List<Assembly> _assemblies;
        private readonly LazyAssemblyLoader _lazyAssemblyLoader = lazyAssemblyLoader;

        public async Task<IReadOnlyList<IModularComponentTypeDefinition>> GetInstances()
        {
            if (_assemblies is null)
            {
                _assemblies = (await LoadAssemblies()).ToList();
            }

            return LoadComponents(_assemblies); ;
        }


        private async Task<IEnumerable<Assembly>> LoadAssemblies()
        {
            var assemblies = await _lazyAssemblyLoader.LoadAssembliesAsync(
            new[] {
            "QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation.wasm",
            "QuizCrafter.ModularComponents.FillInTheBlanks.Presentation.wasm"
            });
            return assemblies;
        }

        private IReadOnlyList<IModularComponentTypeDefinition> LoadComponents(IEnumerable<Assembly> assemblies)
    => assemblies
        .SelectMany(x => x.GetTypes())
        .Where(x => typeof(IModularComponentTypeDefinition).IsAssignableFrom(x) && !x.IsInterface)
        .OrderBy(x => x.Name)
        .Select(Activator.CreateInstance)
        .Cast<IModularComponentTypeDefinition>()
        .ToList();
    }
}
