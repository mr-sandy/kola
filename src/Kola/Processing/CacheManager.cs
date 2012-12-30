using Kola.Model;

namespace Kola.Processing
{
    public class CacheManager : IComponentRenderer
    {
        private readonly IComponentRenderer innerRenderer;

        public CacheManager(IComponentRenderer innerRenderer)
        {
            this.innerRenderer = innerRenderer;
        }

        public IRenderingResponse RenderComponent(IComponent component, RequestContext context)
        {
            return this.innerRenderer.RenderComponent(component, context);
        }
    }
}