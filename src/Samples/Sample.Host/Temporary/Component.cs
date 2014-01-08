namespace Sample.Host.Temporary
{
    using System.Collections.Generic;

    using Kola.Domain;

    public class Component : IComponentInstance
    {
        public string Name { get; set; }

        public IEnumerable<IComponentInstance> Children { get; set; }
    }
}