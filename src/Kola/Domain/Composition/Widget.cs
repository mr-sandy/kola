namespace Kola.Domain.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Extensions;

    public class Widget : ComponentWithProperties
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
            // Add the widget's parameters to the context to be picjed up by any children
            var propertyInstances = this.Properties.Select(p => p.Build(buildContext)).ToList();
            buildContext.ContextSets.Push(new ContextSet(propertyInstances));

            //// Build the content of each area, before adding it to the context to be picked up by any corresponding placeholders
            //var areaDictionary = new Dictionary<string, ComponentInstance>();
            //for (var i = 0; i < this.Areas.Count(); i++)
            //{
            //    var area = this.Areas.ElementAt(i);
            //    areaDictionary.Add(area.Name, area.Build(path.Append(i), buildContext));
            //}

            var areas = this.Areas.Select(
                (a, i) => new { Name = a.Name, Components = a.Build(path.Append(i), buildContext) })
                .ToList()
                .ToDictionary(d => d.Name, d => d.Components);

            //var areas = this.Areas.Select((a, i) => a.Build(path.Append(i), buildContext)).ToList();
            buildContext.AreaContents.Push(areas);

            var specification = buildContext.WidgetSpecificationFinder(this.Name);

            // Notice that we're passing null as the path - we don't want to annotate the components from the widget 
            // specification because they're not components that the editor of the current template can do anything about
            var components = specification.Components.Select((c, i) => c.Build(null, buildContext)).ToList();

            buildContext.AreaContents.Pop();
            buildContext.ContextSets.Pop();

            return new WidgetInstance(path, components);
        }
    }
}