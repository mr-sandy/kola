namespace Kola.Domain.Rendering
{
    public class RenderingInstructions : IRenderingInstructions
    {
        private RenderingInstructions(string cacheControl, bool annotateComponentPaths, bool showAmendments)
        {
            this.CacheControl = cacheControl;
            this.AnnotateComponentPaths = annotateComponentPaths;
            this.ShowAmendments = showAmendments;
        }

        public string CacheControl { get; }

        public bool ShowAmendments { get; }

        public bool AnnotateComponentPaths { get; }

        public static RenderingInstructions BuildForPreview()
        {
            return new RenderingInstructions("no-cache", true, true);
        }

        public static RenderingInstructions Build(string cacheControl)
        {
            return new RenderingInstructions(string.IsNullOrWhiteSpace(cacheControl) ? "no-cache" : cacheControl, false, false);
        }
    }
}