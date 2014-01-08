namespace Integration.Tests.Nancy.Modules.RenderingModuleSpecs.Framework
{
    using System.Collections.Generic;

    using Kola.Domain;

    internal class TestComponent : IComponentInstance
    {
        public string Name { get; set; }

        public IEnumerable<IComponentInstance> Children { get; set; }
    }
}