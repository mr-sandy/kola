namespace Kola.Domain
{
    using System.Collections.Generic;

    public class Composite : Component
    {
        private readonly List<Component> components = new List<Component>();

        public Composite(string name = "")
            : base(name)
        {
        }

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