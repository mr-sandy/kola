namespace Kola.Rendering
{
    using Kola.Domain;

    public interface IProcessor
    {
        IResult Process(IComponentInstance component);
    }
}