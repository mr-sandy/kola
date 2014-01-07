namespace Kola.Rendering
{
    public interface IHandler
    {
        IResult HandleRequest(IComponent component);
    }
}