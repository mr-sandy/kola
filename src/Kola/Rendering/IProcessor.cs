namespace Kola.Rendering
{
    using Kola.Domain;
    using Kola.Domain.Instances;

    public interface IProcessor
    {
        IResult Process(IComponentInstance component);
    }
}