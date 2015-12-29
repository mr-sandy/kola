
namespace Kola.Domain.Instances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Context;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    public class Builder : IBuilder
    {
        private readonly IRenderingInstructions renderingInstructions;
        private readonly Func<string, WidgetSpecification> widgetSpecificationFinder;

        public Builder(IRenderingInstructions renderingInstructions, Func<string, WidgetSpecification> widgetSpecificationFinder)
        {
            this.renderingInstructions = renderingInstructions;
            this.widgetSpecificationFinder = widgetSpecificationFinder;
        }

        public PageInstance Build(Template template, IBuildContext buildContext)
        {
            return new PageInstance(template.Components.Select((c, i) => c.Build(this, new[] { i }, buildContext)).ToList(), this.renderingInstructions);
        }

        public AtomInstance Build(Atom atom, IEnumerable<int> path, IBuildContext buildContext)
        {
            return new AtomInstance(
                path, 
                this.renderingInstructions, 
                atom.Name, 
                atom.Properties.Select(p => p.Build(buildContext)).ToList());
        }

        public ContainerInstance Build(Container container, IEnumerable<int> path, IBuildContext buildContext)
        {
            var propertyInstances = container.Properties.Select(p => p.Build(buildContext)).ToList();

            buildContext.ContextSets.Push(new ContextSet(propertyInstances));

            var children = container.Components.Select((c, i) => c.Build(this, path.Append(i), buildContext)).ToList();

            buildContext.ContextSets.Pop();

            return new ContainerInstance(
                path, 
                this.renderingInstructions, 
                container.Name, 
                propertyInstances, 
                children);
        }

        public WidgetInstance Build(Widget widget, IEnumerable<int> path, IBuildContext buildContext)
        {
            // Add the widget's parameters to the context to be picjed up by any children
            var propertyInstances = widget.Properties.Select(p => p.Build(buildContext)).ToList();
            buildContext.ContextSets.Push(new ContextSet(propertyInstances));

            var areas = widget.Areas.Select(
                (a, i) => new { Name = a.Name, Components = a.Build(this, path.Append(i), buildContext) })
                .ToList()
                .ToDictionary(d => d.Name, d => d.Components);

            buildContext.AreaContents.Push(areas);

            var specification = this.widgetSpecificationFinder(widget.Name);

            // Notice that we're passing null as the path - we don't want to annotate the components from the widget 
            // specification because they're not components that the editor of the current template can do anything about
            var components = specification.Components.Select((c, i) => c.Build(this, null, buildContext)).ToList();

            buildContext.AreaContents.Pop();
            buildContext.ContextSets.Pop();

            return new WidgetInstance(
                path, 
                this.renderingInstructions, 
                components);
        }

        public PlaceholderInstance Build(Placeholder placeholder, IEnumerable<int> path, IBuildContext buildContext)
        {
            var componentInstance = buildContext.AreaContents.Peek().ContainsKey(placeholder.Name)
                                        ? buildContext.AreaContents.Peek()[placeholder.Name]
                                        : null;

            return new PlaceholderInstance(
                path, 
                this.renderingInstructions, 
                componentInstance);
        }

        public AreaInstance Build(Area area, IEnumerable<int> path, IBuildContext buildContext)
        {
            return new AreaInstance(
                path, 
                this.renderingInstructions, 
                area.Components.Select((c, i) => c.Build(this, path.Append(i), buildContext)).ToList());
        }
    }
}