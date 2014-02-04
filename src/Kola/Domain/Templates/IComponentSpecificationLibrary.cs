namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public interface IComponentSpecificationLibrary
    {
        IEnumerable<IComponentSpecification<IComponentTemplate>> FindAll();

        IComponentSpecification<IComponentTemplate> Lookup(string componentName);
    }
}