namespace Kola.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Domain.Instances;

    internal class Page : IPage
    {
        public Page(IEnumerable<IComponentInstance> components = null)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }
    }
}