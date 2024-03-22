using QuizCrafter.ModularComponents.Abstraction.ComponentLoader;
using QuizCrafter.ModularComponents.Abstraction.Core;

namespace QuizCrafter.ModularComponents.Infrastructure.ComponentLoader
{
    public class ModularComponentCollection : IModularComponentCollection
    {
        private readonly IModularComponentLoader _modularComponentLoader;
        private IReadOnlyList<IModularComponentTypeDefinition> _instances;
        public ModularComponentCollection(IModularComponentLoader modularComponentLoader)
        {
            _modularComponentLoader = modularComponentLoader;
        }
        public IModularComponentTypeDefinition this[int index]
        {
            get { return _instances[index]; }
        }

        public async Task<IReadOnlyCollection<IModularComponentTypeDefinition>> GetComponents()
           => await GetOrLoadInstances();


        public Type GetEditableComponentDefinition(ModularComponentModel modularComponentModel)
        {
            return
            _instances?.Where(q => q.ModelType == modularComponentModel.GetType()).FirstOrDefault()?.EditComponentType; // return component not found if null
        }
        

        public Dictionary<string, object> GetParameterDictionary(ModularComponentModel modularComponentModel)
        {
            return
            _instances?.Where(q => q.ModelType == modularComponentModel.GetType()).FirstOrDefault().GetParameterDictionary(modularComponentModel);
        }

        private async Task<IReadOnlyCollection<IModularComponentTypeDefinition>> GetOrLoadInstances()
        {
            if (_instances is null || _instances.Count == 0)
            {
               return _instances = await _modularComponentLoader.GetInstances();
            }

            return _instances;
        }
    }
}
