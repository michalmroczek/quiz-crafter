using QuizCrafter.ModularComponents.Abstraction.Core;

namespace QuizCrafter.ModularComponents.Abstraction.ComponentLoader
{
    public interface IModularComponentCollection
    {
        Type GetEditableComponentDefinition(ModularComponentModel modularComponentModel);

        Task<IReadOnlyCollection<IModularComponentTypeDefinition>> GetComponents();

        Dictionary<string, object> GetParameterDictionary(ModularComponentModel modularComponentModel);

        IModularComponentTypeDefinition this[int index] { get; }
    }
}
