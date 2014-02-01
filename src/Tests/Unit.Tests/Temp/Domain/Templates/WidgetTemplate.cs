namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;

    using Unit.Tests.Temp.Domain.Homeless;
    using Unit.Tests.Temp.Domain.Instances;

    public class WidgetTemplate : ITemplate
    {
        public WidgetTemplate(IEnumerable<Area> areas)
        {
            this.Areas = areas;
        }

        public IEnumerable<Area> Areas { get; private set; }

        public IInstance Build(IBuildContext buildContext)
        {
            return new WidgetInstance();
        }
    }
}