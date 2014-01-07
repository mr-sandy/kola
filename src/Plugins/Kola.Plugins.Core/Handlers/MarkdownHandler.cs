namespace Kola.Plugins.Core.Handlers
{
    using Kola.Rendering;

    public class MarkdownHandler : IHandler
    {
        public IResult HandleRequest(IComponent component)
        {
            var transformer = new MarkdownSharp.Markdown();

            var html = transformer.Transform("*markdown*");

            return new Result(viewHelper => viewHelper.RenderPartial("Markdown", html));
        }
    }
}
