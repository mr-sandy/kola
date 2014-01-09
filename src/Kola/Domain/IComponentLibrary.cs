namespace Kola.Domain
{
    using System.Collections.Generic;

    public interface IComponentLibrary
    {
        IEnumerable<IComponentSpecification> FindAll();

        IComponentSpecification Lookup(string componentName);
    }
}