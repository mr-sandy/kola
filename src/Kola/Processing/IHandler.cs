using Kola.Model;

namespace Kola.Processing
{
    public interface IHandler
    {
        IRenderingResponse HandleRequest(IComponent component, RequestContext context);
    }
}