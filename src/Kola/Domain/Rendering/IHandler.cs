namespace Kola.Domain.Rendering
{
    using Kola.Domain.Instances;

    public interface IHandler<in T>
        where T : IComponentInstance
    {
        IResult Render(T component);
    }
}