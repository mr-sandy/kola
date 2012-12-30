using Kola.Configuration;
using Kola.Model;

namespace Kola.Processing
{
    public interface IHandlerFactory
    {
        IHandler GetHandler(IComponent component);
    }
}