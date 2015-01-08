namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

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

        public string Name { get; private set; }

        public IEnumerable<PropertySpecification> Properties
        {
            get { return this.properties; }
        }

        public void AddProperty(PropertySpecification property)
        {
            this.properties.Add(property);
        }

        public abstract TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor);

        public abstract T Create();
    }
}