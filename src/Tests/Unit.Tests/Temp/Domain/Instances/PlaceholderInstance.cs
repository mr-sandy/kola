namespace Unit.Tests.Temp.Domain.Instances
{
    using System.Collections.Generic;

    public class PlaceholderInstance : IInstance
    {
        public PlaceholderInstance(IEnumerable<IInstance> components)
        {
            this.Components = components;
        }

        public IEnumerable<IInstance> Components { get; private set; }
    }
}