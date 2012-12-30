using System;
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
        public RenderPageReponse RenderPage(Page page, IViewHelper viewHelper)
        {
            var context = this.NewContext(viewHelper);
            var bits = page.Components.Select(c => this.componentRenderer.RenderComponent(c, context));
            bits.ToArray();
            return new RenderPageReponse(bits);
        }

        private RequestContext NewContext(IViewHelper viewHelper)
        {
            return new RequestContext(new CachingHandlerFactory(new CachingHandlerFactory(new HandlerFactory(kolaEngineConfiguration.HandlerMappings, kolaEngineConfiguration.ObjectFactory))), viewHelper);
        }
    }
}