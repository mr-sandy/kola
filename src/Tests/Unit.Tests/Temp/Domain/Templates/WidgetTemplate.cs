namespace Unit.Tests.Temp.Domain.Templates
{
    using System;

    using Unit.Tests.Temp.Domain.Instances;

    public class WidgetTemplate : ITemplate<WidgetInstance>
    {
        public WidgetInstance Build()
        {
            throw new NotImplementedException();
        }
    }
}