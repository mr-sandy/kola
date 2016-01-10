namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Extensions;

    public class WidgetSpecification : AmendableComponentCollection, IComponentSpecification<Widget>
    {
        private readonly List<PropertySpecification> properties = new List<PropertySpecification>();

        public WidgetSpecification(string name, IEnumerable<PropertySpecification> properties = null, IEnumerable<IComponent> components = null, IEnumerable<IAmendment> amendments = null, string category = null)
            : base(components, amendments)
        {
            this.Name = name;
            this.Category = category;

            if (properties != null)
            {
                this.properties.AddRange(properties);
            }
        }

        public Widget Create()
        {
            var areas = this.FindAll<Placeholder>().Select(p => new Area(p.Name, Enumerable.Empty<IComponent>())).ToArray();

            return new Widget(this.Name, areas, this.CreateDefaultProperties());
        }

        public string Name { get; }

        public string Category { get; set; }

        public IEnumerable<PropertySpecification> Properties => this.properties;

        public void AddProperty(PropertySpecification property)
        {
            this.properties.Add(property);
        }

        public TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor)
        {
            return visitor.Visit(this);
        }

        protected IEnumerable<Property> CreateDefaultProperties()
        {
            return this.Properties.Where(p => !string.IsNullOrWhiteSpace(p.DefaultValue)).Select(p => p.Create(new FixedPropertyValue(p.DefaultValue))).ToList();
        }

        public override T Accept<T>(IAmendableComponentCollectionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}