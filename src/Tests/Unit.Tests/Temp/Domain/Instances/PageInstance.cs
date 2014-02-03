namespace Unit.Tests.Temp.Domain.Instances
{
    using System.Collections.Generic;

    public class PageInstance
    {
        public PageInstance(IEnumerable<IComponentInstance> children)
        {
            this.Children = children;
        }

        public IEnumerable<IComponentInstance> Children { get; private set; }
    }
}
