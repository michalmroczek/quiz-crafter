using QuizCrafter.ModularComponents.Abstraction;
using System.Reflection;

namespace QuizCrafter.Web.Services
{
    public class ModularComponentProvider
    {
        private IReadOnlyList<IModularComponentTypeDefinition> _instances;
        private IList<Assembly> _assemblies;
        private IReadOnlyList<IModularComponentTypeDefinition> GetInstances()
        {
            if (_instances == null)
            {
                _assemblies ??= LoadAssemblies();

                _instances = LoadComponents(_assemblies);
            }
            return _instances;
        }

        public IReadOnlyList<IModularComponentTypeDefinition> Instances => GetInstances();

        public IModularComponentTypeDefinition GetTypeDefinitionForomModel(IModularComponentModel model) => Instances.Where(q => q.ModelType == model.GetType()).FirstOrDefault();


        private IList<Assembly> LoadAssemblies()
        {
            const string modulePart = "QuizCrafter.ModularComponents.*";
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
                .ToList();

            foreach (var file in files)
            {
                if (!file.Contains(modulePart))
                {
                    continue;
                }

                var moduleName = file.Split(modulePart)[1].Split(".")[0].ToLowerInvariant();
            }

            files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));
            return assemblies;
        }

        public static IReadOnlyList<IModularComponentTypeDefinition> LoadComponents(IEnumerable<Assembly> assemblies)
    => assemblies
        .SelectMany(x => x.GetTypes())
        .Where(x => typeof(IModularComponentTypeDefinition).IsAssignableFrom(x) && !x.IsInterface)
        .OrderBy(x => x.Name)
        .Select(Activator.CreateInstance)
        .Cast<IModularComponentTypeDefinition>()
        .ToList();
    }
}

