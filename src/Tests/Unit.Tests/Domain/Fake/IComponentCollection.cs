namespace Unit.Tests.Domain.Fake
{
    using System.Collections.Generic;

    public interface IComponentCollection
    {
        IEnumerable<IComponent> Components { get; }

        void AddComponent(IComponent component, int index);
    }
}