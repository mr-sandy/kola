namespace Kola.Domain.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

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
            throw new NotImplementedException();
            //return new CompositeResult(widget.Components.Select(c => c.Render(KolaConfigurationRegistry.Instance.Renderer)));
        }

        public IResult Render(AreaInstance area)
        {
            throw new NotImplementedException();
            //return new CompositeResult(area.Components.Select(c => c.Render(KolaConfigurationRegistry.Instance.Renderer)));
        }

        public IResult Render(PageInstance page)
        {
            throw new NotImplementedException();
            //return new CompositeResult(page.Components.Select(c => c.Render(KolaConfigurationRegistry.Instance.Renderer)));
        }

        public IResult Render(IEnumerable<ComponentInstance> components)
        {
            throw new NotImplementedException();
            //return new CompositeResult(components.Select(c => c.Render(KolaConfigurationRegistry.Instance.Renderer)));
        }
    }
}