namespace Kola.Rendering
{
    using Kola.Domain.Instances;

    public interface IHandler
    {
        IResult Render(IComponentInstance component);
    }
}