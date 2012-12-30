
using System.Collections.Generic;

namespace Kola.Model
{
    public interface IComponent
    {
        string Name { get; }
        IEnumerable<IComponent> Children { get; }
    }

    public class Component : IComponent
    {
        public string Name { get; set; }
        public IEnumerable<IComponent> Children { get; set; }
    }
}
