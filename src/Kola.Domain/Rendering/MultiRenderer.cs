namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public class MultiRenderer : IMultiRenderer
    {
        private readonly IRendererFactory rendererFactory;

        public MultiRenderer(IRendererFactory rendererFactory)
        {
            this.rendererFactory = rendererFactory;
        }

        public IResult Render(AtomInstance atom)
        {
            var result = this.rendererFactory.GetAtomRenderer(atom.Name).Render(atom);

            return this.Annotate(atom, result);
        }

        public IResult Render(ContainerInstance container)
        {
            var result = this.rendererFactory.GetContainerRenderer(container.Name).Render(container);

            return this.Annotate(container, result);
        }

        public IResult Render(WidgetInstance widget)
        {
            var result = new CompositeResult(widget.Components.Select(c => c.Render(this)));

            return this.Annotate(widget, result);
        }

        public IResult Render(AreaInstance area)
        {
            var result = new CompositeResult(area.Components.Select(c => c.Render(this)));

            return this.Annotate(area, result);
        }

        public IResult Render(PageInstance page)
        {
            return new CompositeResult(page.Components.Select(c => c.Render(this)));
        }

        public IResult Render(IEnumerable<ComponentInstance> components)
        {
            return new CompositeResult(components.Select(c => c.Render(this)));
        }

        private IResult Annotate(ComponentInstance component, IResult result)
        {
            return component.RenderingInstructions.AnnotateComponentPaths
                       ? new AnnotatedResult(result, component.Path)
                       : result;
        }
    }
}