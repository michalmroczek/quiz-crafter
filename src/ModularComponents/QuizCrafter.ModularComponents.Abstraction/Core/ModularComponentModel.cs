using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuizCrafter.ModularComponents.Abstraction.Core
{
    public abstract class ModularComponentModel : IModularComponentModel
    {
        [JsonConstructor]
        public ModularComponentModel()
        {        
        }

        public Guid Id { get; set; }
        public int Order { get; set; }

        public abstract string Type { get; }
    }
}
