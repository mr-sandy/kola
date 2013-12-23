namespace Kola.Processing
{
    public interface IHandlerFactory
    {
        IHandler Create(string name);
    }
}