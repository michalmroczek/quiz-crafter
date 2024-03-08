using QuizCrafter.ModularComponents.Abstraction;

namespace QuizCrafter.ModularComponents.FillInTheBlanks.Presentation.Models
{
    public class FillInTheBlanksModel : IModularComponentModel
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
    }
}
