namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Extensions;
    using Kola.Domain.Composition;

    public class WidgetSpecification : ParameterisedComponentSpecification<Widget>, IComponentCollection
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public WidgetSpecification(string name, IEnumerable<IComponent> components = null)
            : base(name)
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

        public override Widget Create()
        {
            var parameters = this.CreateParameters();

            var placeholders = this.FindAll<Placeholder>();
            var areas = placeholders.Select(p => new Area(Enumerable.Empty<IComponent>()));

            return new Widget(this.Name, parameters, areas);
        }
    }
}