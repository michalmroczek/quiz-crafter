using QuizCrafter.ModularComponents.Abstraction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCrafter.ModularComponents.PlaceInCorrectOrder.Presentation.Models
{
    public class PlaceInCorrectOrderModel : IModularComponentModel
    {
        public Guid Id { get; set; }

        public int Order { get; set; }

        internal List<Section> Sections { get; set; }

        internal List<AnswerItem> Answers { get; set; }

    }
}
