namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    public class Area : IComponentCollection
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public Area(IEnumerable<IComponent> components = null)
        {
            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public IEnumerable<IComponent> Components
        {
            get { return this.components; }
        }

        public void AddComponent(IComponent component, int index)
        {
            if (index > this.components.Count)
            {
                throw new KolaException("Specified index outwith bounds of component collection");
            }

            this.components.Insert(index, component);
        }

        public void RemoveComponentAt(int index)
        {
            this.components.RemoveAt(index);
        }
    }
}