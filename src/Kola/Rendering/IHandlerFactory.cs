namespace Kola.Rendering
{
    using Kola.Domain.Instances;

    public interface IHandlerFactory
    {
        IHandler<AtomInstance> GetAtomHandler(string atomName);

        IHandler<ContainerInstance> GetContainerHandler(string containerName);
    }
}