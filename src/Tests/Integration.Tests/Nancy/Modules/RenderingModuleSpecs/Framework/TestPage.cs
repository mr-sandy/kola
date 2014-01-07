namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs.Framework
{
    using System.Collections.Generic;

    using Kola.Processing;

    internal class TestPage : IPage
    {
        public IEnumerable<IComponent> Components { get; set; }
    }
}