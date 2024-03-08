using QuizCrafter.ModularComponents.Abstraction;
using System.Reflection;

namespace QuizCrafter.ModularComponents.Bootstrapper
{
    public class ModularComponentProvider2
    {
        private IReadOnlyList<IModularComponentTypeDefinition> _instances;
        private IList<Assembly> _assemblies;

        private IReadOnlyList<IModularComponentTypeDefinition> GetInstances()
        {
            if(_instances !=null) return _instances;
            if (_assemblies == null || !_assemblies.Any())
            {
                _assemblies = Bootrapper.LoadAssemblies();
            }

            _instances = Bootrapper.LoadComponents(_assemblies);
            return _instances;
        }

        public  IReadOnlyList<IModularComponentTypeDefinition> Instances => GetInstances();

        public  IModularComponentTypeDefinition GetTypeDefinitionForomModel(IModularComponentModel model) => Instances.Where(q => q.ModelType == model.GetType()).FirstOrDefault();
    }
}
