namespace Kola.Domain.Specifications
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

    public interface IComponentSpecification<out T> 
        where T : IComponentWithProperties
    {
        string Name { get; }

        IEnumerable<PropertySpecification> Properties { get; }

        void AddProperty(PropertySpecification property);

        TV Accept<TV>(IComponentSpecificationVisitor<TV> visitor);

        T Create();
    }
}