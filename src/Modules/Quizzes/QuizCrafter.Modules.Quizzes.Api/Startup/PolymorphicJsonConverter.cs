using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace QuizCrafter.Modules.Quizzes.Api.Startup
{
    public class PolymorphicJsonConverter<TBase> : JsonConverter<TBase> where TBase : ModularComponents.Abstraction.Core.ModularComponentModel
    {
        private readonly IDictionary<string, Type> _typeMapping;

        public PolymorphicJsonConverter()
        {

            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            var directoryAssemblies = Directory.GetFiles(Path.GetDirectoryName(assemblyPath), "QuizCrafter.ModularComponents.*.Presentation.dll")
                                                .Select(Assembly.LoadFrom);

            var derivedTypesFromDirectory = FindDerivedTypes<TBase>(directoryAssemblies);
            _typeMapping = new Dictionary<string, Type>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var baseType = typeof(TBase);


            foreach (var type in derivedTypesFromDirectory)
            {
                if (type.IsClass && !type.IsAbstract && baseType.IsAssignableFrom(type))
                {
                    _typeMapping.Add(type.Name, type);
                }
            }
        }

        List<Type> FindDerivedTypes<TBase>(IEnumerable<Assembly> assemblies)
        {
            var baseType = typeof(TBase);
            var derivedTypes = new List<Type>();

            foreach (var assembly in assemblies)
            {
                try
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.IsClass && !type.IsAbstract && baseType.IsAssignableFrom(type))
                        {
                            derivedTypes.Add(type);
                        }
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                }
                catch (Exception)
                {
                    // Handle or log other exceptions if necessary
                }
            }

            return derivedTypes;
        }
        public override TBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                var root = jsonDoc.RootElement;
                var typeDiscriminator = root.GetProperty("type").GetString();

                if (_typeMapping.TryGetValue(typeDiscriminator, out var targetType))
                {
                    return JsonSerializer.Deserialize(root.GetRawText(), targetType, options) as TBase;
                }

                throw new JsonException($"Unable to determine the type for discriminator {typeDiscriminator}");
            }
        }

        public override void Write(Utf8JsonWriter writer, TBase value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
