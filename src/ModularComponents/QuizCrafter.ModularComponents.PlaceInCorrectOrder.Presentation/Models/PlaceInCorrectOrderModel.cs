using QuizCrafter.ModularComponents.Abstraction.Core;

namespace QuizCrafter.ModularComponents.PlaceInCorrectOrder.Presentation.Models
{
    public class PlaceInCorrectOrderModel : ModularComponentModel
    {
        public Guid Id { get; set; }

        public int Order { get; set; }

        internal List<Section> Sections { get; set; }

        internal List<AnswerItem> Answers { get; set; }

    }
}
