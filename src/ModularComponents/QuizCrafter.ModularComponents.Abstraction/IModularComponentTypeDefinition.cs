namespace QuizCrafter.ModularComponents.Abstraction
{
    public interface IModularComponentTypeDefinition
    {
        public Type EditComponentType { get; }

        public Type IconComponentType { get; }

        public Type ModelType { get; }

        public IModularComponentModel CreateModel();

        public Dictionary<string, object> GetParameterDictionary(object parameterObject);
    }
}
