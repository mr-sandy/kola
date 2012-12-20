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

        public RenderComponentReponse RenderComponent(Component component)
        {
            return this.innerRenderer.RenderComponent(component);
        }
    }
}