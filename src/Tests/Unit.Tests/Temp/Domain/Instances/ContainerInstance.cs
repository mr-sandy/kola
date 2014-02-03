namespace Unit.Tests.Temp.Domain.Instances
{
    using System.Collections.Generic;

    public class ContainerInstance : IComponentInstance
    {
        public ContainerInstance(IEnumerable<IComponentInstance> children)
        {
            this.Children = children;
        }

        public IEnumerable<IComponentInstance> Children { get; private set; }
    }
}
