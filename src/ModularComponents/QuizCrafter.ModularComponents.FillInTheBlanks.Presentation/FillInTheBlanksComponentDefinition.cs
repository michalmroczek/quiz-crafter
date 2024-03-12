using MudBlazor;
using QuizCrafter.ModularComponents.Abstraction.Core;
using QuizCrafter.ModularComponents.FillInTheBlanks.Presentation.Components;
using QuizCrafter.ModularComponents.FillInTheBlanks.Presentation.Models;

namespace QuizCrafter.ModularComponents.FillInTheBlanks.Presentation
{
    public class FillInTheBlanksComponentDefinition : IModularComponentTypeDefinition
    {
        public Type EditComponentType => typeof(FillInTheBlankEditable);

        public string DisplayName => "Fill in the blanks";

        public string Icon => Icons.Material.Filled.QueryBuilder;

        public Type ModelType => typeof(FillInTheBlanksModel);

        public IModularComponentModel CreateModel()
        {
            return new FillInTheBlanksModel();
        }

        public Dictionary<string, object> GetParameterDictionary(object parameterObject) => new Dictionary<string, object>() { { nameof(FillInTheBlanksModel), parameterObject } };

    }
}
