namespace Kola.Editing
{
    using System.Collections.Generic;

    public class CompositeComponent : Component
    {
        private readonly List<Component> components = new List<Component>();

        public CompositeComponent(string name = "", IEnumerable<Component> components = null)
            : base(name)
        {
            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public IEnumerable<Component> Components
        {
            get { return this.components; }
        }

        public void AddComponent(Component component, int? index = null)
        {
            if (index.HasValue)
            {
                this.components.Insert(index.Value, component);
            }
            else
            {
                this.components.Add(component);
            }
        }

        public void RemoveComponentAt(int index)
        {
            this.components.RemoveAt(index);
        }

        public override void Accept(IComponentVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}