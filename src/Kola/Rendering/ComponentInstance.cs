namespace Kola.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain;

    internal class ComponentInstance : IComponentInstance
    {
        public ComponentInstance(string name, IEnumerable<IComponentInstance> children = null)
        {
            this.Name = name;
            this.Children = children;
        }

        public string Name { get; private set; }

        public IEnumerable<IComponentInstance> Children { get; private set; }
    }
}