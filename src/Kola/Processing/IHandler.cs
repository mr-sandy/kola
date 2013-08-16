using Kola.Domain;

namespace Kola.Processing
{
    public interface IHandler
    {
        IRenderingResponse HandleRequest(IComponent component, RequestContext context);
    }
}