using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCrafter.ModularComponents.FillInTheBlanks.Presentation.Models
{
    public class TextWithBlank
    {
        public int order { get; set; }
        public string Text { get; set; }
        public BlankAnswer BlankAnswer { get; set; }
    }
}
