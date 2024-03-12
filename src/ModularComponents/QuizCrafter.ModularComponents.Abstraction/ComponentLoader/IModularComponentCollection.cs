using QuizCrafter.ModularComponents.Abstraction.Core;

namespace QuizCrafter.ModularComponents.Abstraction.ComponentLoader
{
    public interface IModularComponentCollection
    {
        Type GetEditableComponentDefinition(IModularComponentModel modularComponentModel);

        Task<IReadOnlyCollection<IModularComponentTypeDefinition>> GetComponents();

        Dictionary<string, object> GetParameterDictionary(IModularComponentModel modularComponentModel);

        IModularComponentTypeDefinition this[int index] { get; }
    }
}
