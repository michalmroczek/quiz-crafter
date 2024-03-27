using System.Reflection;

namespace QuizCrafter.Shared.Infrastructure.AssemblyLoaders
{
    public class TypeFinder<TBase>
    {
        private readonly Dictionary<string, Type> _typeMapping;
        private readonly string _assemblySearchPattern;

        public TypeFinder(string assemblySearchPattern)
        {
            _typeMapping = new Dictionary<string, Type>();
            _assemblySearchPattern = assemblySearchPattern;
            InitializeTypeMapping();
        }

        private void InitializeTypeMapping()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            var directoryAssemblies = Directory.GetFiles(Path.GetDirectoryName(assemblyPath), _assemblySearchPattern)
                                                .Select(Assembly.LoadFrom);

            var derivedTypesFromDirectory = FindDerivedTypes(directoryAssemblies);

            foreach (var type in derivedTypesFromDirectory)
            {
                if (type.IsClass && !type.IsAbstract && typeof(TBase).IsAssignableFrom(type))
                {
                    _typeMapping.Add(type.Name, type);
                }
            }
        }

        private IEnumerable<Type> FindDerivedTypes(IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(TBase).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                    {
                        yield return type;
                    }
                }
            }
        }

        public Type GetTypeByName(string typeName)
        {
            _typeMapping.TryGetValue(typeName, out Type foundType);
            return foundType;
        }
    }

}
