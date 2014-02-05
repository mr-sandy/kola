namespace Kola.Domain.Instances
{
    using Kola.Domain.Rendering;

    public interface IComponentInstance
    {
        IResult Render(IRenderer renderer);
    }
}