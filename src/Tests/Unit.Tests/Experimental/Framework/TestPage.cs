namespace Unit.Tests.Experimental.Framework
{
    using System;
    using System.Collections.Generic;

    internal class TestPage : IPage
    {
        public IEnumerable<IComponent> Components { get; set; }
    }
}