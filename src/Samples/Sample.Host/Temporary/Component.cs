namespace Sample.Host.Temporary
{
    using System.Collections.Generic;

    using Kola.Domain;

    public class Component : IComponent
    {
        public string Name { get; set; }

        public IEnumerable<IComponent> Children { get; set; }
    }
}