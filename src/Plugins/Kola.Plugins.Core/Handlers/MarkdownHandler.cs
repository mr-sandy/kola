namespace Kola.Plugins.Core.Handlers
{
    using System;
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    public class MarkdownHandler : IHandler<AtomInstance>
    {
        public IResult Render(AtomInstance atom)
        {
            var transformer = new MarkdownSharp.Markdown();

            var markdownParameter = atom.Parameters.Where(p => p.Name.Equals("markdown", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            var markdown = markdownParameter == null
                ? string.Empty
                : markdownParameter.Value;

            var html = transformer.Transform(markdown);

            return new Result(viewHelper => viewHelper.RenderPartial("Markdown", html));
        }
    }
}
