using Kola.Configuration;
using Kola.Domain;

namespace Kola.Processing
{
    public interface IHandlerFactory
    {
        IHandler GetHandler(IComponent component);
    }
}