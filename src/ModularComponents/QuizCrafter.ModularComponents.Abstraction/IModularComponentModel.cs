namespace QuizCrafter.ModularComponents.Abstraction
{
    public interface IModularComponentModel
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
    }
}
