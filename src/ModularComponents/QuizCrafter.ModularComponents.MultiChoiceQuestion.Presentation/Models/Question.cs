using QuizCrafter.ModularComponents.Abstraction.Core;

namespace QuizCrafter.ModularComponents.MultiChoiceQuestion.Presentation.Models
{
    public class Question : ModularComponentModel
    {
        public Question()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string Text { get; set; }

        public IEnumerable<Answer> Answers => _answers;

        public override string Type => nameof(Question);

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
