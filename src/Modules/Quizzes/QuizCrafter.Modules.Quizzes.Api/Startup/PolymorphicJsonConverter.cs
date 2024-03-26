using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace QuizCrafter.Modules.Quizzes.Api.Startup
{
    public class PolymorphicJsonConverter<TBase> : Newtonsoft.Json.JsonConverter where TBase : ModularComponents.Abstraction.Core.ModularComponentModel
    {
        private readonly IDictionary<string, Type> _typeMapping;

        public PolymorphicJsonConverter()
        {
            _typeMapping = new Dictionary<string, Type>();
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            var directoryAssemblies = Directory.GetFiles(Path.GetDirectoryName(assemblyPath), "QuizCrafter.ModularComponents.*.Presentation.dll")
                                                .Select(Assembly.LoadFrom);

            var derivedTypesFromDirectory = FindDerivedTypes<TBase>(directoryAssemblies);

            foreach (var type in derivedTypesFromDirectory)
            {
                if (type.IsClass && !type.IsAbstract && typeof(TBase).IsAssignableFrom(type))
                {
                    _typeMapping.Add(type.Name, type);
                }
            }
        }

        private List<Type> FindDerivedTypes<T>(IEnumerable<Assembly> assemblies)
        {
            var baseType = typeof(T);
            var derivedTypes = new List<Type>();

            foreach (var assembly in assemblies)
            {
                try
                {
                    derivedTypes.AddRange(assembly.GetTypes()
                        .Where(type => type.IsClass && !type.IsAbstract && baseType.IsAssignableFrom(type)));
                }
                catch (ReflectionTypeLoadException)
                {
                    // Optionally handle or log exceptions
                }
                catch (Exception)
                {
                    // Handle or log other exceptions if necessary
                }
            }

            return derivedTypes;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(TBase).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            var typeDiscriminator = item["Type"].Value<string>();

            if (_typeMapping.TryGetValue(typeDiscriminator, out var targetType))
            {
                // Create a new JsonSerializer that doesn't include the problematic converter
                var newSerializer = new Newtonsoft.Json.JsonSerializer();
                foreach (var converter in serializer.Converters)
                {
                    if (!(converter is PolymorphicJsonConverter<TBase>))
                    {
                        newSerializer.Converters.Add(converter);
                    }
                }

                // Populate and return the object without causing recursion
                return item.ToObject(targetType, newSerializer);
            }

            throw new Newtonsoft.Json.JsonException($"Unable to determine the type for discriminator {typeDiscriminator}");
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, value.GetType());
        }
    }
}
