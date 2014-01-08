namespace Kola.Domain
{
    using System.Collections.Generic;

    public interface IPage
    {
        IEnumerable<IComponent> Components { get; }
    }
}