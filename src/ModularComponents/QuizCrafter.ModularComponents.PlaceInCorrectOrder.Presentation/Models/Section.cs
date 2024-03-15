using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCrafter.ModularComponents.PlaceInCorrectOrder.Presentation.Models
{
    internal class Section
    {
        public int Id { get; }
        public string Name { get; set; }

        public List<AnswerItem> Answers { get; set; }
    }
}
