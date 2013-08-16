using System.Collections.Generic;

namespace Kola.Domain
{
    public class Component : IComponent
    {
        public string Name { get; set; }
        public IEnumerable<IComponent> Children { get; set; }
    }
}
