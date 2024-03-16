using QuizCrafter.ModularComponents.Abstraction.Core;
using static MudBlazor.CategoryTypes;

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

        public void AddQuestion(IModularComponentModel question, int index)
        {
            int order = _questions.Any() ? _questions.Max(q => q.Order) + 1 : 1;
            question.Order = order;

            if (index < QuestionCount)
            {
                _questions.Insert(index, question);
            }
            else
            {
                _questions.Add(question);
            }
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

        public void ChangeOrder(int oldIndex, int newIndex)
        {

                // Assuming quiz.Questions is a collection that supports .ToList()
                var items = _questions.ToList();
                var itemToMove = items[oldIndex];

                // Remove the item from its old position
                items.RemoveAt(oldIndex);

                // Now we insert the item at the new index. If the new index is beyond the last position, Add the item instead.
                if (newIndex < items.Count)
                {
                    items.Insert(newIndex, itemToMove);
                }
                else
                {
                    items.Add(itemToMove);
                }

            int index = 1; // Assuming you want Order to start at 1

            for (int i = 0; i < items.Count; i++)
            {
                items[i].Order = i + 1; // Assuming you want Order to start at 1
            }

            // Assuming you need to update the original Questions list with the new order
            _questions = items; // Make sure quiz.Questions can be assigned a list, or use an appropriate method to update its contents.
        }
    }
}
