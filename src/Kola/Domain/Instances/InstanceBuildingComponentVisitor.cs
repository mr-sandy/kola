namespace Kola.Domain.Instances
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances.Context;
    using Kola.Extensions;

    public class InstanceBuildingComponentVisitor : IComponentVisitor<ComponentInstance, IEnumerable<int>, IBuildContext>
    {
        public ComponentInstance Visit(Atom atom, IEnumerable<int> path, IBuildContext buildContext)
        {
            return new AtomInstance(
                path,
                atom.Name,
                atom.Properties.Select(p => p.Build(buildContext)).ToList());
        }

        public ComponentInstance Visit(Container container, IEnumerable<int> path, IBuildContext buildContext)
        {
            var propertyInstances = container.Properties.Select(p => p.Build(buildContext)).ToList();

            buildContext.ContextSets.Push(new ContextSet(propertyInstances));

            var children = container.Components.Select((c, i) => c.Accept(this, path.Append(i), buildContext)).ToList();

            buildContext.ContextSets.Pop();

            return new ContainerInstance(path, container.Name, propertyInstances, children);
        }

        public ComponentInstance Visit(Widget widget, IEnumerable<int> path, IBuildContext buildContext)
        {
            // Add the widget's parameters to the context to be picjed up by any children
            var propertyInstances = widget.Properties.Select(p => p.Build(buildContext)).ToList();
            buildContext.ContextSets.Push(new ContextSet(propertyInstances));

            var areas = widget.Areas.Select(
                (a, i) => new { Name = a.Name, Components = a.Accept(this, path.Append(i), buildContext) })
                .ToList()
                .ToDictionary(d => d.Name, d => d.Components);

            buildContext.AreaContents.Push(areas);

            var specification = buildContext.WidgetSpecificationFinder(widget.Name);

            // Notice that we're passing null as the path - we don't want to annotate the components from the widget 
            // specification because they're not components that the editor of the current template can do anything about
            var components = specification.Components.Select((c, i) => c.Accept(this, null, buildContext)).ToList();

            buildContext.AreaContents.Pop();
            buildContext.ContextSets.Pop();

            return new WidgetInstance(path, components);
        }

        public ComponentInstance Visit(Placeholder placeholder, IEnumerable<int> path, IBuildContext buildContext)
        {
            var componentInstance = buildContext.AreaContents.Peek().ContainsKey(placeholder.Name)
                                        ? buildContext.AreaContents.Peek()[placeholder.Name]
                                        : null;

            return new PlaceholderInstance(path, componentInstance);
        }

        public ComponentInstance Visit(Area area, IEnumerable<int> path, IBuildContext buildContext)
        {
            return new AreaInstance(path, area.Components.Select((c, i) => c.Accept(this, path.Append(i), buildContext)).ToList());
        }
    }
}