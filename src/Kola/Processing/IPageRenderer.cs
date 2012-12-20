using Kola.Model;

namespace Kola.Processing
{
    public interface IComponentRenderer
    {
        RenderComponentReponse RenderComponent(Component component);
    }
}