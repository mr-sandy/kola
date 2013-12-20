namespace Unit.Tests.Experimental.Framework
{
    using System.Collections.Generic;

    internal class TestComponent : IComponent
    {
        public string Name { get; set; }

        public IEnumerable<IComponent> Children { get; set; }
    }
}