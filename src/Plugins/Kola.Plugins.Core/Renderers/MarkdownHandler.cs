namespace Kola.Plugins.Core.Renderers
{
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    public class MarkdownRenderer : IRenderer<AtomInstance>
    {
        public IResult Render(AtomInstance atom)
        {
            var transformer = new MarkdownSharp.Markdown();

            var markdown = atom.Parameters.Get("markdown");

            var html = transformer.Transform(markdown);

            return new Result(viewHelper => viewHelper.RenderPartial("Markdown", html));
        }
    }
}
