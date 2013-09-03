namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain;

    public interface IComponentTypeRepository
    {
        IEnumerable<ComponentType> FindAll();
    }
}