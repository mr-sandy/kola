namespace Kola.Processing
{
    public interface IProcessor
    {
        IResult Process(IComponent component);
    }
}