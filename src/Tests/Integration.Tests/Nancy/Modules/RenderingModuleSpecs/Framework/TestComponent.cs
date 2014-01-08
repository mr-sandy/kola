namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs.Framework
{
    using System.Collections.Generic;

    using Kola.Domain;

    internal class TestComponent : IComponent
    {
        public string Name { get; set; }

        public IEnumerable<IComponent> Children { get; set; }
    }
}