namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    using Kola.Domain.Specifications;

    public interface IComponentSpecificationLibrary
    {
        IEnumerable<IComponentSpecification<IComponent>> FindAll();

        IComponentSpecification<IComponent> Lookup(string componentName);
    }
}