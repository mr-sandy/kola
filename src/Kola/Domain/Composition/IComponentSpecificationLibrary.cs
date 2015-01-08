namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public interface IComponentSpecificationLibrary
    {
        IEnumerable<IComponentSpecification<IComponentWithProperties>> FindAll();

        IComponentSpecification<IComponentWithProperties> Lookup(string componentName);
    }
}