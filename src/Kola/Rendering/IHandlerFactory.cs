namespace Kola.Rendering
{
    using Kola.Domain;

    public interface IHandlerFactory
    {
        IHandler Create(IComponentInstance component);
    }
}