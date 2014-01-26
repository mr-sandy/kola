namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Extensions;
    using Kola.Domain.Templates;

    public class WidgetSpecification : IComponentSpecification<Widget>, IComponentCollection
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public WidgetSpecification(string name, IEnumerable<IComponent> components = null)
        {
            this.Name = name;

            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public string Name { get; private set; }

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

        public Widget Create()
        {
            // TODO {SC} Add widget parameters
            var parameters = Enumerable.Empty<Parameter>();
            var areas = this.FindAll<Placeholder>();

            return new Widget(this.Name, parameters, areas.Select(p => p.Create()));
        }
    }
}