namespace Kola.Domain.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Extensions;

    public class WidgetSpecification : ComponentSpecification<Widget>, IComponentCollection
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
            var placeholders = this.FindAll<Placeholder>();
            var areas = placeholders.Select(p => new Area(Enumerable.Empty<IComponent>())).ToArray();

            return new Widget(this.Name, areas);
        }

        public override TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor)
        {
            return visitor.Visit(this);
        }
    }
}