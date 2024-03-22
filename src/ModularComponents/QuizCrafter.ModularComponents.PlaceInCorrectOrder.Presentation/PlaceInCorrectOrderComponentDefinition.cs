using QuizCrafter.ModularComponents.Abstraction.Core;

namespace QuizCrafter.ModularComponents.PlaceInCorrectOrder.Presentation
{
    public class PlaceInCorrectOrderComponentDefinition : IModularComponentTypeDefinition
    {
        public Type EditComponentType => typeof(string);

        public string DisplayName => "Place in correct order";

        public string Icon => MudBlazor.Icons.Filled.List;

        public Type ModelType => throw new NotImplementedException();

        public ModularComponentModel CreateModel()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetParameterDictionary(object parameterObject)
        {
            throw new NotImplementedException();
        }
    }
}
