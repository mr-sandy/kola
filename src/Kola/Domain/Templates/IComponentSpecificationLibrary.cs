namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public interface IComponentSpecificationLibrary
    {
        IEnumerable<INamedComponentSpecification<INamedComponentTemplate>> FindAll();

        INamedComponentSpecification<INamedComponentTemplate> Lookup(string componentName);
    }
}