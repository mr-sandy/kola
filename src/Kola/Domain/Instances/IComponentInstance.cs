namespace Kola.Domain.Instances
{
    using Kola.Rendering;

    public interface IComponentInstance
    {
        string Name { get; }

        IResult Render(IHandlerFactory handlerFactory);
    }
}