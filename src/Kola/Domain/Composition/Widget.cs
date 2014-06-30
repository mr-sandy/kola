namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public class Widget : ParameterisedComponent
    {
        public Widget(string name, IEnumerable<Area> areas, IEnumerable<Parameter> parameters = null)
            : base(name, parameters)
        {
            this.Areas = areas;
        }

        public IEnumerable<Area> Areas { get; private set; }

        public override T Accept<T>(IComponentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }

        public override IComponentInstance Build(IBuildContext buildContext)
        {
            // Build the content of each area, 
            // before adding it to the context to be 
            // picked up by any corresponding placeholders
            var areas = this.Areas.Select(a => a.Build(buildContext)).ToList();

            buildContext.AreaContents.Push(new Queue<IComponentInstance>(areas));

            var specification = buildContext.WidgetSpecificationFinder(this.Name);
            var components = specification.Components.Select(c => c.Build(buildContext)).ToList();

            buildContext.AreaContents.Pop();

            return new WidgetInstance(components);
        }
    }
}