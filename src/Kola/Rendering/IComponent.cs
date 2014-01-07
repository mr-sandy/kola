namespace Kola.Rendering
{
    using System.Collections.Generic;

    public interface IComponent
    {
        string Name { get; }

        IEnumerable<IComponent> Children { get; }
    }
}