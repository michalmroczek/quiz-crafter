using QuizCrafter.ModularComponents.Abstraction.Core;

namespace QuizCrafter.Shared.Contracts.Quizzes.Dto
{
    public class QuizDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserCreatorId { get; set; }
        public List<string> Tags { get; set; }
        public IEnumerable<IModularComponentModel> Questions {get;set; }
    }
}
