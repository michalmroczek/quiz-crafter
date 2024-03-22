using MudBlazor;
using QuizCrafter.ModularComponents.Abstraction.Core;
using QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation.Components;
using QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation.Models;

namespace QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation
{
    public class MultiChoiceQuestionComponentDefinition : IModularComponentTypeDefinition
    {
        public string DisplayName => "Multi choice question";

        public Type EditComponentType => typeof(QuestionEditable);

        public Type ModelType => typeof(Question);

        public string Icon => Icons.Material.Filled.Quiz;

        public ModularComponentModel CreateModel()
        {
            return new Question();
        }

        public Dictionary<string, object> GetParameterDictionary(object parameterObject) => new Dictionary<string, object>() { { nameof(Question), parameterObject } };
    }
}
