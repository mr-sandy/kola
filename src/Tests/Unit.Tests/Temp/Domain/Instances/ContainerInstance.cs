namespace Unit.Tests.Temp.Domain.Instances
{
    using System.Collections.Generic;

    public class ContainerInstance : IInstance
    {
        public ContainerInstance(IEnumerable<IInstance> children)
        {
            this.Children = children;
        }

        public IEnumerable<IInstance> Children { get; private set; }
    }
}
