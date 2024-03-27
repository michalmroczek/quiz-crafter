using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizCrafter.Shared.Infrastructure.AssemblyLoaders;

namespace QuizCrafter.Modules.Quizzes.Api.Startup
{
    public class PolymorphicJsonConverter<TBase> : Newtonsoft.Json.JsonConverter where TBase : ModularComponents.Abstraction.Core.ModularComponentModel
    {
        private readonly TypeFinder<TBase> _typeFinder;

        public PolymorphicJsonConverter()
        {

            _typeFinder = new TypeFinder<TBase>("QuizCrafter.ModularComponents.*.Presentation.dll");
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
            var targetType = _typeFinder.GetTypeByName(typeDiscriminator);
            if (targetType is not null)
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

            throw new JsonException($"Unable to determine the type for discriminator {typeDiscriminator}");
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, value.GetType());
        }
    }
}
