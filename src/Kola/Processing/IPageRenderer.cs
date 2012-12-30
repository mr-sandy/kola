using Kola.Model;

namespace Kola.Processing
{
    public interface IComponentRenderer
    {
        RenderComponentReponse RenderComponent(IComponent component, RequestContext context);
    }
}