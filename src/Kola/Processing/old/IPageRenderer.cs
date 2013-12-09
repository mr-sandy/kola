using Kola.Domain;

namespace Kola.Processing
{
    public interface IComponentRenderer
    {
        IRenderingResponse RenderComponent(Component component, RequestContext context);
    }
}