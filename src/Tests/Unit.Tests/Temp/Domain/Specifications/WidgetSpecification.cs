namespace Unit.Tests.Temp.Domain.Specifications
{
    using System.Collections.Generic;
    using System.Linq;

    using Unit.Tests.Temp.Domain.Templates;

    public class WidgetSpecification : IComponentSpecification<WidgetTemplate>
    {
        private readonly List<IComponentTemplate> components = new List<IComponentTemplate>();

        public WidgetSpecification(string name, IEnumerable<IComponentTemplate> components)
        {
            this.Name = name;

            if (components != null)
            {
                this.components.AddRange(components);
            }
        }

        public string Name { get; private set; }

        public IEnumerable<IComponentTemplate> Components
        {
            get { return this.components; }
        }

        public WidgetTemplate Create()
        {
            var placeholders = new PlaceholderFinder().FindPlaceholders(this.components);

            var areas = placeholders.Select(p => new Area(Enumerable.Empty<IComponentTemplate>()));

            return new WidgetTemplate(this.Name, areas);
        }
    }

    internal class PlaceholderFinder
    {
        public IEnumerable<Placeholder> FindPlaceholders(IEnumerable<IComponentTemplate> components)
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