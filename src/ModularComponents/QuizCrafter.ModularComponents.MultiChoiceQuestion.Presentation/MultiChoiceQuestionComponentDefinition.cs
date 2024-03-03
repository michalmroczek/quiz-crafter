using QuizCrafter.ModularComponents.Abstraction;
using QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation.Components;
using QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation.Models;

namespace QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation
{
    public class MultiChoiceQuestionComponentDefinition : IModularComponentTypeDefinition
    {
        public Type EditComponentType => typeof(QuestionEditable);

        public Type IconComponentType => typeof(QuestionIcon);

        public Type ModelType => typeof(Question);

        public IModularComponentModel CreateModel()
        {
            return new Question();
        }

        public Dictionary<string, object> GetParameterDictionary(object parameterObject) => new Dictionary<string, object>() { { "Question", parameterObject } };
    }
}
