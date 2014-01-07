namespace Kola.Nancy
{
    using System.Collections.Generic;

    using Kola.Configuration;

    public interface IComponentRegistry
    {
        IEnumerable<ComponentSpecification> FindAll();
    }
}