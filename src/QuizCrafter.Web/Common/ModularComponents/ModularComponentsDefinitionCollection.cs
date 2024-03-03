using QuizCrafter.ModularComponents.Abstraction;
using QuizCrafter.ModularComponents.Bootstrapper;
using System.Reflection;
namespace QuizCrafter.Web.Common.ModularComponents
{
    public static class ModularComponentsDefinitionCollection
    {
        private static readonly IReadOnlyList<IModularComponentTypeDefinition> _instances;
        private static readonly IList<Assembly> _assemblies;
         static  ModularComponentsDefinitionCollection()
        {

             _assemblies = Bootrapper.LoadAssemblies();
             _instances = Bootrapper.LoadComponents(_assemblies);

        }

        public static IReadOnlyList<IModularComponentTypeDefinition> Instances => _instances;

        public static IModularComponentTypeDefinition GetTypeDefinitionForomModel(IModularComponentModel model) => Instances.Where(q => q.ModelType == model.GetType()).FirstOrDefault();
    }
}

