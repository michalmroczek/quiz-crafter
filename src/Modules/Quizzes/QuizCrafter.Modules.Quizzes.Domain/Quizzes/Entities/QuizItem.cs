using QuizCrafter.ModularComponents.Abstraction.Core;

namespace QuizCrafter.Modules.Quizzes.Domain.Quizzes.Entities
{
    public class QuizItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserCreatorId { get; set; }
        public List<string> Tags { get; set; }
        public IEnumerable<ModularComponentModel> Questions { get; set; }
    }
}
