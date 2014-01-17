namespace Kola.Domain
{
    using System.Collections.Generic;

    public interface IComponentLibrary
    {
        IEnumerable<IComponentSpecification<IComponent>> FindAll();

        IComponentSpecification<IComponent> Lookup(string componentName);
    }
}