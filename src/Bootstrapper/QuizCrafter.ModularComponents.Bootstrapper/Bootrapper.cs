using System.Reflection;
using QuizCrafter.ModularComponents.Abstraction;

namespace QuizCrafter.ModularComponents.Bootstrapper
{
    public static class Bootrapper
    {

        public static IList<Assembly> LoadAssemblies()
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
