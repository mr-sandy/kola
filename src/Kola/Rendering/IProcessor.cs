namespace Kola.Rendering
{
    public interface IProcessor
    {
        IResult Process(IComponent component);
    }
}