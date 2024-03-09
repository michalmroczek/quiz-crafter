using QuizCrafter.ModularComponents.Abstraction;
using System.Collections;
using System.Collections.Generic;

namespace QuizCrafter.ModularComponents.FillInTheBlanks.Presentation.Models
{
    public class FillInTheBlanksModel : IModularComponentModel
    {
        public Guid Id { get; set; }
        public int Order { get; set; }

        public List<TextWithBlank> textWithBlanks { get; set; }
    }
}
