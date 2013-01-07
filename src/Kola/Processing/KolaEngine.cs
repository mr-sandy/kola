using System.Collections.Generic;
using System.Linq;
using Kola.Model;

namespace Kola.Processing
{
    public class KolaEngine
    {
        private readonly KolaEngineConfiguration kolaEngineConfiguration;
        private readonly IComponentRenderer componentRenderer;

        public KolaEngine(KolaEngineConfiguration kolaEngineConfiguration)
        {
            this.kolaEngineConfiguration = kolaEngineConfiguration;

            this.componentRenderer = new CacheManager(new ComponentRenderer());
        }

        public IHtmlResponse RenderPage(Page page)
        {
            var context = this.NewContext();
            return new PageRenderingResponse(page, this.BuildCompositeRenderingResponse(page.Components, context));
        }

        public IRenderingResponse RenderComponents(IEnumerable<IComponent> components)
        {
            var context = this.NewContext();
            return this.BuildCompositeRenderingResponse(components, context);
        }

        private IRenderingResponse BuildCompositeRenderingResponse(IEnumerable<IComponent> components, RequestContext context)
        {
            return new CompositeRenderingResponse(components.Select(c => this.componentRenderer.RenderComponent(c, context)));
        }

        private RequestContext NewContext()
        {
            return new RequestContext(new CachingHandlerFactory(new HandlerFactory(kolaEngineConfiguration.HandlerMappings, kolaEngineConfiguration.ObjectFactory)));
        }
    }
}