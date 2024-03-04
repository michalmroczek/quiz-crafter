namespace QuizCrafter.ModularComponents.Abstraction
{
    public interface IModularComponentTypeDefinition
    {
        public Type EditComponentType { get; }

        public string DisplayName { get; }

        public string Icon { get; }

        public Type ModelType { get; }

        public IModularComponentModel CreateModel();

        public Dictionary<string, object> GetParameterDictionary(object parameterObject);
    }
}
