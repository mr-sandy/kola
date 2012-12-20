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
        public RenderPageReponse RenderPage(Page page)
        {
            var bits = page.Components.Select(c => this.componentRenderer.RenderComponent(c));

            return new RenderPageReponse(bits);
        }
    }

    public class RenderPageReponse
    {
        public RenderPageReponse(IEnumerable<RenderComponentReponse> renderComponentReponses)
        {
            
        }

        public string Html { get; set; }
    }

    public class RenderComponentReponse
    {
        public string Html { get; set; }
    }
}