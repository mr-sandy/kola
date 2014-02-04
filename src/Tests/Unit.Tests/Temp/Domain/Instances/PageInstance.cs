namespace Unit.Tests.Temp.Domain.Instances
{
    using System.Collections.Generic;

    public class PageInstance
    {
        public PageInstance(IEnumerable<IComponentInstance> components)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }
    }
}
