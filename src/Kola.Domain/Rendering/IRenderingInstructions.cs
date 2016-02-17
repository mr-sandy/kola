namespace Kola.Domain.Rendering
{
    public interface IRenderingInstructions
    {
        string CacheControl { get; }

        bool AnnotateComponentPaths { get; }

        bool ShowAmendments { get; }
    }
}