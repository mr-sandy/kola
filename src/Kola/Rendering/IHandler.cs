namespace Kola.Rendering
{
    using Kola.Domain.Instances;

    public interface IHandler<T>
        where T : IComponentInstance
    {
        IResult Render(T component);
    }
}