namespace Kola.Domain.Rendering
{
    public interface IRenderingInstructions
    {
        bool UseCache { get; }

        bool AnnotateComponentPaths { get; }
    }
}