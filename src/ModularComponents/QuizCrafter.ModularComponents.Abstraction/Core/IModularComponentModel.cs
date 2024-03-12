namespace QuizCrafter.ModularComponents.Abstraction.Core
{
    public interface IModularComponentModel
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
    }
}
