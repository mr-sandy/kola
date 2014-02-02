namespace Unit.Tests.Temp.Domain
{
    using System.Collections.Generic;

    public interface IContainer
    {
        IEnumerable<IComponent> Children { get; }
    }
}