namespace Kola.Configuration
{
    using System.Collections.Generic;

    using Kola.Editing;

    public interface IComponentTypeRegistry
    {
        IEnumerable<ComponentType> FindAll();
    }
}