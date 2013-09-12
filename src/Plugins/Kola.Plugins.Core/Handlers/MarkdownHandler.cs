using Kola.Domain;
using Kola.Processing;

namespace Kola.Plugins.Core.Handlers
{
    public class MarkdownHandler : IHandler
    {
        public IRenderingResponse HandleRequest(Component component, RequestContext context)
        {
            var transformer = new MarkdownSharp.Markdown();

            var html = transformer.Transform("*markdown*");

            return new RenderingResponse(viewHelper => viewHelper.RenderPartial("Markdown", html), null);
        }
    }
}
