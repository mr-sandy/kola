namespace Unit.Tests.Temp.Domain.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Unit.Tests.Temp.Domain.Templates;

    public class WidgetSpecification : ISpecification<WidgetTemplate>
    {
        private readonly List<IComponent> components = new List<IComponent>();

        public WidgetSpecification(string name, IEnumerable<IComponent> components)
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

        public WidgetTemplate Create()
        {
            var placeholders = new PlaceholderFinder().FindPlaceholders(this.components);

            var areas = placeholders.Select(p => new Area(Enumerable.Empty<IComponent>()));

            return new WidgetTemplate(this.Name, areas);
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