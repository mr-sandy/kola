namespace Kola.Domain
{
    using System.Collections.Generic;

    public interface IComponentInstance
    {
        string Name { get; }

        IEnumerable<IComponentInstance> Children { get; }
    }
}