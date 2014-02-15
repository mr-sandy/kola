namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public interface IComponentSpecificationLibrary
    {
        IEnumerable<IParameterisedComponentSpecification<IParameterisedComponent>> FindAll();

        IParameterisedComponentSpecification<IParameterisedComponent> Lookup(string componentName);
    }
}