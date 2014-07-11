namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Nancy;

    // TODO the references to the NancyKolaConfigurationRegistry seems a bit stinky
    public class MultiRenderer : IMultiRenderer
    {
        private readonly IRendererFactory rendererFactory;

        public MultiRenderer(IRendererFactory rendererFactory)
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
            return new CompositeResult(widget.Components.Select(c => c.Render(NancyKolaConfigurationRegistry.Instance.Renderer)));
        }

        public IResult Render(AreaInstance area)
        {
            return new CompositeResult(area.Components.Select(c => c.Render(NancyKolaConfigurationRegistry.Instance.Renderer)));
        }

        public IResult Render(PageInstance page)
        {
            return new CompositeResult(page.Components.Select(c => c.Render(NancyKolaConfigurationRegistry.Instance.Renderer)));
        }

        public IResult Render(IEnumerable<ComponentInstance> components)
        {
            return new CompositeResult(components.Select(c => c.Render(NancyKolaConfigurationRegistry.Instance.Renderer)));
        }
    }
}