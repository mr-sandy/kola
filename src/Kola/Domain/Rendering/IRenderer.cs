namespace Kola.Domain.Rendering
{
    public interface IRenderer<in T>
    {
        IResult Render(T component);
    }
}