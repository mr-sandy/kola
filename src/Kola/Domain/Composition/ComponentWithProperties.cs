namespace Kola.Domain.Composition
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Extensions;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;
    using Kola.Domain.Specifications;

    public abstract class ComponentWithProperties : IComponentWithProperties
    {
        private readonly List<Property> properties = new List<Property>();

        protected ComponentWithProperties(string name, IEnumerable<Property> properties)
        {
            this.Name = name;

            if (properties != null)
            {
                this.properties.AddRange(properties);
            }
        }

        public string Name { get; private set; }

        public IEnumerable<Property> Properties
        {
            get { return this.properties; }
        }

        public Property FindOrCreateProperty(PropertySpecification specification)
        {
            var property = this.properties.Find(specification.Name);

            if (property == null)
            {
                property = specification.Create();
                this.properties.Add(property);
            }

            return property;
        }


        // TODO {SC} Some tests for this, please!
        public void RemoveProperty(Property property)
        {
            this.properties.Remove(property);
        }

        public abstract void Accept(IComponentVisitor visitor);

        public abstract T Accept<T>(IComponentVisitor<T> visitor);

        public abstract T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context);

        public abstract ComponentInstance Build(IBuilder builder, IEnumerable<int> path, IBuildContext buildContext);

        public abstract IComponent Clone();
    }
}