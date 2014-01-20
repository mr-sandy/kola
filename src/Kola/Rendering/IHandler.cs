namespace Kola.Rendering
{
    using Kola.Domain;
    using Kola.Domain.Instances;

    public interface IHandler
    {
        IResult HandleRequest(IComponentInstance component);
    }
}