using System.Text.Json.Serialization;

namespace QuizCrafter.ModularComponents.Abstraction.Core
{
    public abstract class ModularComponentModel : IModularComponentModel
    {
        [JsonConstructor]
        public ModularComponentModel()
        {        
        }
        public Guid QuizItemId { get; set; }

        public Guid Id { get; set; }
        public int Order { get; set; }

        private string _type;

        public virtual string Type => GetType().Name;
    }
}
