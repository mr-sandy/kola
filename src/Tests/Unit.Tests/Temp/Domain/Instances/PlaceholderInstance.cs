namespace Unit.Tests.Temp.Domain.Instances
{
    using System.Collections.Generic;

    public class PlaceholderInstance : IComponentInstance
    {
        public PlaceholderInstance(IEnumerable<IComponentInstance> components)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }
    }
}