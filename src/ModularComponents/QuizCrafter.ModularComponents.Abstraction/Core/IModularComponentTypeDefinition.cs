namespace QuizCrafter.ModularComponents.Abstraction.Core
{
    public interface IModularComponentTypeDefinition
    {
        public Type EditComponentType { get; }

        public string DisplayName { get; }

        public string Icon { get; }

        public Type ModelType { get; }

        public ModularComponentModel CreateModel();

        public Dictionary<string, object> GetParameterDictionary(object parameterObject);
    }
}
