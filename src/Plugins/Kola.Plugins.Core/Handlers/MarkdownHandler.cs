namespace Kola.Plugins.Core.Handlers
{
    using Kola.Domain;
    using Kola.Domain.Instances;
    using Kola.Rendering;

    public class MarkdownHandler : IHandler
    {
        public IResult HandleRequest(IComponentInstance component)
        {
            var transformer = new MarkdownSharp.Markdown();

            var html = transformer.Transform("*markdown*");

            return new Result(viewHelper => viewHelper.RenderPartial("Markdown", html));
        }
    }
}
