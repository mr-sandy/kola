﻿namespace Kola.Domain.Composition
{
    using System.Collections.Generic;

    public interface IComponentCollection
    {
        IEnumerable<IComponent> Components { get; }

        void AddComponent(IComponent component, int index);

        void RemoveComponentAt(int index);
    }
}