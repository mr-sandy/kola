namespace Kola.Domain.Rendering
{
    public class RenderingInstructions : IRenderingInstructions
    {
        public RenderingInstructions(bool isPreview)
            : this(useCache: !isPreview, annotateComponentPaths: isPreview, showAmendments: isPreview)
        {
        }

        public RenderingInstructions(bool useCache, bool annotateComponentPaths, bool showAmendments)
        {
            this.UseCache = useCache;
            this.AnnotateComponentPaths = annotateComponentPaths;
            this.ShowAmendments = showAmendments;
        }

        public bool UseCache { get; }

        public bool ShowAmendments { get; }

        public bool AnnotateComponentPaths { get; }
    }
}