using Kola.Domain;

namespace Kola.Processing
{
    public interface IComponentRenderer
    {
        IRenderingResponse RenderComponent(IComponent component, RequestContext context);
    }
}