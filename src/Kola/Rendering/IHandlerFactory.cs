namespace Kola.Rendering
{
    public interface IHandlerFactory
    {
        IHandler GetHandler(string componentName);
    }
}