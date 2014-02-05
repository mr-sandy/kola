namespace Kola.Plugins.Core.Handlers
{
    using System;
    using System.Linq;

    using Kola.Domain;
    using Kola.Domain.Instances;
    using Kola.Rendering;

    public class MarkdownHandler : IHandler
    {
        public IResult Render(IComponentInstance component)
        {
            var transformer = new MarkdownSharp.Markdown();

            // TODO {SC} Anyway of not having to cast here?  Different types of IHandler?
            var markdownParameter = ((AtomInstance)component).Parameters.Where(p => p.Name.Equals("markdown", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            var markdown = markdownParameter == null
                ? string.Empty
                : markdownParameter.Value;

            var html = transformer.Transform(markdown);

            return new Result(viewHelper => viewHelper.RenderPartial("Markdown", html));
        }
    }
}
