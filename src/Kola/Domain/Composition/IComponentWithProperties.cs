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

        // TODO 2015 - we need to do three things:
        // 1. Create properties with dfault value on initial creation of component
        // 2. Allow new and existing parameters to have values set
        // 3. Refresh properties from updated specifications - adding any new properties with default value
        // 4. SUpply all specified properties (with and without values) out to the resource to show in editor 
    }
}