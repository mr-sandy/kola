namespace Unit.Tests.Experimental.Stubs
{
    using System.Collections.Generic;

    using Kola.Experimental;

    internal class TestKolaComponent : IKolaComponent
    {
        public string Name { get; set; }

        public IEnumerable<IKolaComponent> Children { get; set; }
    }
}