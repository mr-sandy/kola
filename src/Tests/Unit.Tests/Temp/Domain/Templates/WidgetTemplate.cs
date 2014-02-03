namespace Unit.Tests.Temp.Domain.Templates
{
    using System.Collections.Generic;
    using System.Linq;

    using Unit.Tests.Temp.Domain.Instances;

    public class WidgetTemplate : IComponentTemplate
    {
        public WidgetTemplate(string name, IEnumerable<Area> areas)
        {
            this.Name = name;
            this.Areas = areas;
        }

        public string Name { get; private set; }

        public IEnumerable<Area> Areas { get; private set; }

        public IComponentInstance Build(IBuildContext buildContext)
        {
            var specification = buildContext.WidgetSpecificationLocator(this.Name);

            buildContext.Areas.Push(new Queue<Area>(this.Areas));

            var children = specification.Components.Select(c => c.Build(buildContext)).ToList();

            buildContext.Areas.Pop();

            return new WidgetInstance(children);
        }
    }
}