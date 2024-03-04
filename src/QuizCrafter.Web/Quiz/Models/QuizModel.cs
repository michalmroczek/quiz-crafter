using QuizCrafter.ModularComponents.Abstraction;

namespace QuizCrafter.Web.Quiz.Models
{
    public class QuizModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserCreatorId { get; set; }
        public List<string> Tags { get; set; }
        public IEnumerable<IModularComponentModel> Questions => _questions;
        public int QuestionCount => _questions.Count();

        private IList<IModularComponentModel> _questions;

        public QuizModel()
        {
            Id = Guid.NewGuid();
            Tags = new List<string>();
            _questions = new List<IModularComponentModel>();
        }

        public void AddQuestion(IModularComponentModel question)
        {
            int order = _questions.Any() ? _questions.Max(q => q.Order) + 1 : 1;
            question.Order = order;
            _questions.Add(question);
        }

        public void RemoveQuestion(Guid questionId)
        {
            var questionToRemove = _questions.First(q => q.Id == questionId);
            foreach (var question in _questions.Where(q => q.Order > questionToRemove.Order))
            {
                question.Order--;
            }

            _questions.Remove(questionToRemove);
        }
    }
}
