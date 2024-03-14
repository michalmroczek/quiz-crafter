using QuizCrafter.ModularComponents.Abstraction.Core;

namespace QuizCrafter.ModularComponents.Abstraction.ComponentLoader
{
    public interface IModularComponentLoader
    {
        public Task<IReadOnlyList<IModularComponentTypeDefinition>> GetInstances();
    }
}
