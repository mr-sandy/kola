
namespace Kola.Domain.Instances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Config;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    public class Builder : IBuilder
    {
        private readonly IRenderingInstructions renderingInstructions;
        private readonly Func<string, WidgetSpecification> widgetSpecificationFinder;
        private readonly IComponentSpecificationLibrary componentLibrary;

        public Builder(IRenderingInstructions renderingInstructions, Func<string, WidgetSpecification> widgetSpecificationFinder, IComponentSpecificationLibrary componentLibrary)
        {
            this.renderingInstructions = renderingInstructions;
            this.widgetSpecificationFinder = widgetSpecificationFinder;
            this.componentLibrary = componentLibrary;
        }

        public PageInstance Build(Template template, IBuildData buildData)
        {
            return new PageInstance(template.Components.Select((c, i) => c.Build(this, new[] { i }, buildData)).ToList(), this.renderingInstructions);
        }

        public AtomInstance Build(Atom atom, IEnumerable<int> path, IBuildData buildData)
        {
            return new AtomInstance(
                path, 
                this.renderingInstructions, 
                atom.Name, 
                atom.Properties.Select(p => p.Build(buildData)).ToList());
        }

        public ContainerInstance Build(Container container, IEnumerable<int> path, IBuildData buildData)
        {
            var propertyInstances = container.Properties.Select(p => p.Build(buildData)).ToList();

            buildData.ContextSets.Push(new ContextSet(propertyInstances));

            var children = container.Components.Select((c, i) => c.Build(this, path.Append(i), buildData)).ToList();

            buildData.ContextSets.Pop();

            return new ContainerInstance(
                path, 
                this.renderingInstructions, 
                container.Name, 
                propertyInstances, 
                children);
        }

        public WidgetInstance Build(Widget widget, IEnumerable<int> path, IBuildData buildData)
        {
            // Add the widget's parameters to the context to be picked up by any children
            var propertyInstances = widget.Properties.Select(p => p.Build(buildData)).ToList();
            buildData.ContextSets.Push(new ContextSet(propertyInstances));

            var areas = widget.Areas.Select(
                (a, i) => new { Name = a.Name, Components = a.Build(this, path.Append(i), buildData) })
                .ToList()
                .ToDictionary(d => d.Name, d => d.Components);

            buildData.AreaContents.Push(areas);

            var specification = this.widgetSpecificationFinder(widget.Name);

            if (this.renderingInstructions.ShowAmendments)
            {
                specification.ApplyAmendments(this.componentLibrary);
            }

            // Notice that we're passing null as the path - we don't want to annotate the components from the widget 
            // specification because they're not components that the editor of the current template can do anything about
            var components = specification.Components.Select((c, i) => c.Build(this, null, buildData)).ToList();

            buildData.AreaContents.Pop();
            buildData.ContextSets.Pop();

            return new WidgetInstance(
                path, 
                this.renderingInstructions, 
                components);
        }

        public PlaceholderInstance Build(Placeholder placeholder, IEnumerable<int> path, IBuildData buildData)
        {
            var componentInstance = buildData.AreaContents.Peek().ContainsKey(placeholder.Name)
                                        ? buildData.AreaContents.Peek()[placeholder.Name]
                                        : null;

            return new PlaceholderInstance(
                path, 
                this.renderingInstructions, 
                componentInstance);
        }

        public AreaInstance Build(Area area, IEnumerable<int> path, IBuildData buildData)
        {
            return new AreaInstance(
                path, 
                this.renderingInstructions, 
                area.Components.Select((c, i) => c.Build(this, path.Append(i), buildData)).ToList());
        }
    }
}