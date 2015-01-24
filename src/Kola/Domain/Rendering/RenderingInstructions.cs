namespace Kola.Domain.Rendering
{
    public class RenderingInstructions : IRenderingInstructions
    {
        public RenderingInstructions(bool useCache, bool annotateComponentPaths)
        {
            this.UseCache = useCache;
            this.AnnotateComponentPaths = annotateComponentPaths;
        }

        public bool UseCache { get; private set; }

        public bool AnnotateComponentPaths { get; private set; }
    }
}