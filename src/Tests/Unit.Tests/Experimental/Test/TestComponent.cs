namespace Unit.Tests.Experimental.Test
{
    using System.Collections.Generic;

    using Unit.Tests.Experimental.Framework;

    internal class TestComponent : IComponent
    {
        public string Name { get; set; }

        public IEnumerable<IComponent> Children { get; set; }
    }
}