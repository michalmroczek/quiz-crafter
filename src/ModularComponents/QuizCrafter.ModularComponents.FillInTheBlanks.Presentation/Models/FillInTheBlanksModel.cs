using QuizCrafter.ModularComponents.Abstraction.Core;
using System.Collections;
using System.Collections.Generic;

namespace QuizCrafter.ModularComponents.FillInTheBlanks.Presentation.Models
{
    public class FillInTheBlanksModel : ModularComponentModel
    {
        public Guid Id { get; set; }
        public int Order { get; set; }

        public List<TextWithBlank> textWithBlanks { get; set; }
    }
}
