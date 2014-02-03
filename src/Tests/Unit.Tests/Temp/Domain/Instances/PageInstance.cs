namespace Unit.Tests.Temp.Domain.Instances
{
    using System.Collections.Generic;

    public class PageInstance : IInstance
    {
        public PageInstance(IEnumerable<IInstance> children)
        {
            this.Children = children;
        }

        public IEnumerable<IInstance> Children { get; private set; }
    }
}
