namespace Unit.Tests.Rendering.Framework
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Rendering;

    internal class TestPage : IPage
    {
        public IEnumerable<IComponent> Components { get; set; }
    }
}