using System;
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

        //Should a page be a special case of a component?
        public IRenderingResponse RenderPage(Page page)
        {
            var context = this.NewContext();
            var bits = page.Components.Select(c => this.componentRenderer.RenderComponent(c, context));
            return new PageRenderingResponse(bits);
        }

        public IRenderingResponse RenderComponents(IEnumerable<IComponent> components)
        {
            var context = this.NewContext();
            var bits = components.Select(c => this.componentRenderer.RenderComponent(c, context));
            return new CompositeRenderingResponse(bits);
        }

        private RequestContext NewContext()
        {
            return new RequestContext(new CachingHandlerFactory(new HandlerFactory(kolaEngineConfiguration.HandlerMappings, kolaEngineConfiguration.ObjectFactory)));
        }
    }
}