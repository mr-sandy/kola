namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs.Framework
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Rendering;

    internal class TestPage : IPage
    {
        public IEnumerable<IComponentInstance> Components { get; set; }
    }
}