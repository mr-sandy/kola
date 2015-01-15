namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Extensions;

    public class Widget : ComponentWithgProperties
    {
        public Widget(string name, IEnumerable<Area> areas, IEnumerable<Property> properties = null)
            : base(name, properties)
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

        public override ComponentInstance Build(IEnumerable<int> path, IBuildContext buildContext)
        {
            var newContext = new Context { Items = this.Properties.Select(p => new ContextItem(p.Name, p.Value.Resolve(buildContext))) };

            buildContext.PushContext(newContext);

            // Build the content of each area, 
            // before adding it to the context to be 
            // picked up by any corresponding placeholders
            var areas = this.Areas.Select((a, i) => a.Build(path.Append(i), buildContext)).ToList();

            buildContext.AreaContents.Push(new Queue<ComponentInstance>(areas));

            var specification = buildContext.WidgetSpecificationFinder(this.Name);

            // Notice that we're passing null as the path - we don't want to annotate the components from the widget 
            // specification because they're not components that the editor of the current template can do anything about
            var components = specification.Components.Select((c, i) => c.Build(null, buildContext)).ToList();

            buildContext.AreaContents.Pop();
            buildContext.PopContext();

            return new WidgetInstance(path, components);
        }
    }
}