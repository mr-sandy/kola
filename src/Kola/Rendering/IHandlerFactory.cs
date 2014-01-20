namespace Kola.Rendering
{
    using Kola.Domain;
    using Kola.Domain.Instances;

    public interface IHandlerFactory
    {
        IHandler Create(IComponentInstance component);
    }
}