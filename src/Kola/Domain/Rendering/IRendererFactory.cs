namespace Kola.Domain.Rendering
{
    using Kola.Domain.Instances;

    public interface IRendererFactory
    {
        IRenderer<AtomInstance> GetAtomRenderer(string atomName);

        IRenderer<ContainerInstance> GetContainerRenderer(string containerName);
    }
}