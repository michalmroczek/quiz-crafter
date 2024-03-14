using Microsoft.JSInterop;
using QuizCrafter.ModularComponents.Abstraction.Core;
using QuizCrafter.ModularComponents.PlaceInCorrectOrder.Presentation.Models;

namespace QuizCrafter.ModularComponents.PlaceInCorrectOrder.Presentation
{
    public class PlaceInCorrectOrderComponentDefinition : IModularComponentTypeDefinition
    {
        public Type EditComponentType => typeof(string);

        public string DisplayName => "Place in correct order";

        public string Icon => "";

        public Type ModelType => throw new NotImplementedException();

        public IModularComponentModel CreateModel()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetParameterDictionary(object parameterObject)
        {
            throw new NotImplementedException();
        }
    }
}
