namespace Unit.Tests.Experimental.Framework
{
    using System.Collections.Generic;

    public interface IPage
    {
        IEnumerable<IComponent> Components { get; }
    }
}