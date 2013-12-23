namespace Kola.Processing
{
    public interface IHandler
    {
        IResult HandleRequest(IComponent component);
    }
}