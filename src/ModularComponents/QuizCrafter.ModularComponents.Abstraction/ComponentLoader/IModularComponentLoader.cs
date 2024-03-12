using QuizCrafter.ModularComponents.Abstraction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCrafter.ModularComponents.Abstraction.ComponentLoader
{
    public interface IModularComponentLoader
    {
        public Task<IReadOnlyList<IModularComponentTypeDefinition>> GetInstances();
    }
}
