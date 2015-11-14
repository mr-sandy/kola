namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    public class PageInstance
    {
        public PageInstance(IEnumerable<ComponentInstance> components)
        {
            this.Components = components;
        }

        public IEnumerable<ComponentInstance> Components { get; private set; }
    }
}