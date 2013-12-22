namespace Unit.Tests.Experimental.Test
{
    using System.Collections.Generic;

    using Unit.Tests.Experimental.Framework;

    internal class TestPage : IPage
    {
        public IEnumerable<IComponent> Components { get; set; }
    }
}