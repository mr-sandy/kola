namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    public interface IComponentCollection
    {
        IEnumerable<IComponentTemplate> Components { get; }

        void AddComponent(IComponentTemplate component, int index);

        void RemoveComponentAt(int index);
    }
}