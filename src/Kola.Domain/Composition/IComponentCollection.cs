namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    public interface IComponentCollection
    {
        IEnumerable<IComponent> Components { get; }

        void Insert(int index, IComponent component);

        void RemoveAt(int index);
    }
}