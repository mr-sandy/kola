namespace Kola.Domain
{
    using System.Collections.Generic;

    public abstract class Composite
    {
        private readonly List<Component> components = new List<Component>();

        public IEnumerable<Component> Components
        {
            get { return this.components; }
        }

        public void AddComponent(Component component)
        {
            this.components.Add(component);
        }
    }
}