namespace Unit.Tests.Temp.Domain.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Unit.Tests.Temp.Domain.Templates;

    public class WidgetSpecification : ISpecification<WidgetTemplate>
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public IEnumerable<IComponent> Components
        {
            get { return this.components; }
        }

        public void Add(AtomTemplate atom, IEnumerable<int> path)
        {
            if (path.Count() == 1)
            {
                this.components.Insert(path.Single(), atom);
            }
        }

        public void Add(ContainerTemplate container, IEnumerable<int> path)
        {
            if (path.Count() == 1)
            {
                this.components.Insert(path.Single(), container);
            }
        }

        public void Add(WidgetTemplate widget, IEnumerable<int> path)
        {
            if (path.Count() == 1)
            {
                this.components.Insert(path.Single(), widget);
            }
        }

        public void Add(Placeholder placeholder, IEnumerable<int> path)
        {
            if (path.Count() == 1)
            {
                this.components.Insert(path.Single(), placeholder);
            }
        }

        public WidgetTemplate Create()
        {
            var placeholders = new PlaceholderFinder().FindPlaceholders(this.components);

            var areas = placeholders.Select(p => new Area());

            return new WidgetTemplate(areas);
        }
    }

    internal class PlaceholderFinder
    {
        public IEnumerable<Placeholder> FindPlaceholders(IEnumerable<IComponent> components)
        {
            foreach (var component in components)
            {
                if (component is Placeholder)
                {
                    yield return (Placeholder)component;
                }
                else if (component is IContainer)
                {
                    foreach (var childPlaceholder in this.FindPlaceholders(((IContainer)component).Children))
                    {
                        yield return childPlaceholder;
                    }
                }
            }
        }
    }
}