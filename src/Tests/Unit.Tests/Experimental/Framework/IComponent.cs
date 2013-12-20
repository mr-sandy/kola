namespace Unit.Tests.Experimental.Framework
{
    using System.Collections.Generic;

    public interface IComponent
    {
        string Name { get; }

        IEnumerable<IComponent> Children { get; }
    }
}