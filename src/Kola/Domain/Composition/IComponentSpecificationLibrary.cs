namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public interface IComponentSpecificationLibrary
    {
        IEnumerable<IComponentSpecification<IParameterisedComponent>> FindAll();

        IComponentSpecification<IParameterisedComponent> Lookup(string componentName);
    }
}