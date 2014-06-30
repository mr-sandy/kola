namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public class Renderer : IRenderer
    {
        private readonly IRendererFactory rendererFactory;

        public Renderer(IRendererFactory rendererFactory)
        {
            this.rendererFactory = rendererFactory;
        }

        public IResult Render(AtomInstance atom)
        {
            return this.rendererFactory.GetAtomRenderer(atom.Name).Render(atom);
        }

        public IResult Render(ContainerInstance container)
        {
            return this.rendererFactory.GetContainerRenderer(container.Name).Render(container);
        }

        public IResult Render(WidgetInstance widget)
        {
            return new CompositeResult(widget.Components.Select(c => c.Render(this)));
        }

        public IResult Render(AreaInstance area)
        {
            return new CompositeResult(area.Components.Select(c => c.Render(this)));

            //return area == null
            //    ? (IResult)new EmptyResult()
            //    : new CompositeResult(area.Components.Select(c => c.Render(this)));
        }

        public IResult Render(PageInstance page)
        {
            return new CompositeResult(page.Components.Select(c => c.Render(this)));
        }

        public IResult Render(IEnumerable<IComponentInstance> components)
        {
            return new CompositeResult(components.Select(c => c.Render(this)));
        }
    }
}