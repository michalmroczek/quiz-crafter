using Microsoft.AspNetCore.Components.WebAssembly.Services;
using QuizCrafter.ModularComponents.Abstraction;
using System.Reflection;

namespace QuizCrafter.Web.Services.ModularComponents
{
    public class ModularComponentProvider
    {
        private IReadOnlyList<IModularComponentTypeDefinition> _instances;
        private List<Assembly> _assemblies;
        private readonly LazyAssemblyLoader _lazyAssemblyLoader;
        public ModularComponentProvider(LazyAssemblyLoader lazyAssemblyLoader)
        {
            _lazyAssemblyLoader = lazyAssemblyLoader;
        }

        public void Initialize(IEnumerable<Assembly> assemblies)
        {
            _assemblies = assemblies.ToList();
            _instances = LoadComponents(_assemblies);
        }

        public async Task<IReadOnlyList<IModularComponentTypeDefinition>> GetInstances()
        {
            if (_instances == null)
            {
                if (_assemblies is null) { await LoadAssemblies(); }

                _instances = LoadComponents(_assemblies);
            }

            return _instances;
        }

        public IReadOnlyList<IModularComponentTypeDefinition> Instances => _instances;

        public IModularComponentTypeDefinition GetTypeDefinitionForomModel(IModularComponentModel model) => _instances.Where(q => q.ModelType == model.GetType()).FirstOrDefault();


        private async Task LoadAssemblies()
        {
            var assemblies = await _lazyAssemblyLoader.LoadAssembliesAsync(
            new[] {
            "QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation.wasm",
            "QuizCrafter.ModularComponents.FillInTheBlanks.Presentation.wasm"
            });
            _assemblies = assemblies.ToList();
        }

        public IReadOnlyList<IModularComponentTypeDefinition> LoadComponents(IEnumerable<Assembly> assemblies)
    => assemblies
        .SelectMany(x => x.GetTypes())
        .Where(x => typeof(IModularComponentTypeDefinition).IsAssignableFrom(x) && !x.IsInterface)
        .OrderBy(x => x.Name)
        .Select(Activator.CreateInstance)
        .Cast<IModularComponentTypeDefinition>()
        .ToList();
    }
}

