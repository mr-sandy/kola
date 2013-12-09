using Kola.Domain;

namespace Kola.Processing
{
    public interface IHandler
    {
        IRenderingResponse HandleRequest(Component component, RequestContext context);
    }
}