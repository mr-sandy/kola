namespace Kola.Rendering
{
    using Kola.Domain;

    public interface IHandler
    {
        IResult HandleRequest(IComponentInstance component);
    }
}