namespace Unit.Tests.Temp.Domain.Instances
{
    using System.Collections.Generic;

    public class ContainerInstance : IComponentInstance
    {
        public ContainerInstance(IEnumerable<IComponentInstance> components)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }
    }
}
