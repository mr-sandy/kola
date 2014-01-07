namespace Kola.Rendering
{
    public interface IHandlerFactory
    {
        IHandler Create(string name);
    }
}