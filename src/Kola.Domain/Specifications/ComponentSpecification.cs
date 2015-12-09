namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;

    public abstract class ComponentSpecification<T> : IComponentSpecification<T>
        where T : IComponentWithProperties
    {
        private readonly List<PropertySpecification> properties = new List<PropertySpecification>();

        protected ComponentSpecification(string name, IEnumerable<PropertySpecification> properties = null)
        {
            this.Name = name;

            if (properties != null)
            {
                this.properties.AddRange(properties);
            }
        }

        public string Name { get; }

        public string Category { get; set; }

        public IEnumerable<PropertySpecification> Properties => this.properties;

        public void AddProperty(PropertySpecification property)
        {
            this.properties.Add(property);
        }

        public abstract TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor);

        public abstract T Create();

        protected IEnumerable<Property> CreateDefaultProperties()
        {
            return this.Properties.Where(p => !string.IsNullOrWhiteSpace(p.DefaultValue)).Select(p => p.Create(new FixedPropertyValue(p.DefaultValue))).ToList();
        }
    }
}