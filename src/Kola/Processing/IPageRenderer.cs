using Kola.Model;

namespace Kola.Processing
{
    public interface IComponentRenderer
    {
        IRenderingResponse RenderComponent(IComponent component, RequestContext context);
    }
}