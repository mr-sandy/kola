namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public interface IComponentWithProperties : IComponent
    {
        string Name { get; }

        IEnumerable<Property> Properties { get; }

        Property FindOrCreateProperty(PropertySpecification specification);

        void RemoveProperty(Property property);

        string Comment { get; set; }
    }
}