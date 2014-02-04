namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Extensions;
    using Kola.Domain.Templates;

    public class WidgetSpecification : IComponentSpecification<WidgetTemplate>, IComponentCollection
    {
        private readonly List<IComponentTemplate> components = new List<IComponentTemplate>();

        public WidgetSpecification(string name, IEnumerable<IComponentTemplate> components = null)
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

        public void AddComponent(IComponentTemplate component, int index)
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

        public WidgetTemplate Create()
        {
            // TODO {SC} Add widget parameters
            var parameters = Enumerable.Empty<ParameterTemplate>();

            var placeholders = this.FindAll<PlaceholderTemplate>();
            var areas = placeholders.Select(p => new Area(Enumerable.Empty<IComponentTemplate>()));

            return new WidgetTemplate(this.Name, parameters, areas);
        }
    }
}