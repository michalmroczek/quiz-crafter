using QuizCrafter.ModularComponents.Abstraction;

namespace QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation.Models
{
    public class Question : IModularComponentModel
    {
        public Question()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string Text { get; set; }

        public IEnumerable<Answer> Answers => _answers;

        private IList<Answer> _answers = new List<Answer>();

        public void AddAnswer(Answer answer)
        {
            _answers.Add(answer);
        }

        public void RemoveAnswer(Answer answer)
        {
            _answers.Remove(answer);
        }
    }
}
