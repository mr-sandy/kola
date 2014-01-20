namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    internal class Page : IPage
    {
        public Page(IEnumerable<IComponentInstance> components = null)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }
    }
}