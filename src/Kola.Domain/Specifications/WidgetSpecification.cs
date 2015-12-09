namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Extensions;

    public class WidgetSpecification : ComponentSpecification<Widget>, IComponentCollection
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public WidgetSpecification(string name, IEnumerable<PropertySpecification> properties = null, IEnumerable<IComponent> components = null, string category = null)
            : base(name, properties)
        {
            if (components != null)
            {
                this.components.AddRange(components);
            }

            this.Category = category;
        }

        public IEnumerable<IComponent> Components => this.components;

        public void Insert(int index, IComponent component)
        {
            if (index > this.components.Count)
            {
                throw new KolaException("Specified index outwith bounds of component collection");
            }

            this.components.Insert(index, component);
        }

        public void RemoveAt(int index)
        {
            this.components.RemoveAt(index);
        }

        public override Widget Create()
        {
            var areas = this.FindAll<Placeholder>().Select(p => new Area(p.Name, Enumerable.Empty<IComponent>())).ToArray();

            return new Widget(this.Name, areas, this.CreateDefaultProperties());
        }

        public override TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}