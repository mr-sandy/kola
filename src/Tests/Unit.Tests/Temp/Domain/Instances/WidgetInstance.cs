namespace Unit.Tests.Temp.Domain.Instances
{
    using System.Collections.Generic;

    public class WidgetInstance : IComponentInstance
    {
        public WidgetInstance(IEnumerable<IComponentInstance> components)
        {
            this.Components = components;
        }

        public IEnumerable<IComponentInstance> Components { get; private set; }
    }
}
