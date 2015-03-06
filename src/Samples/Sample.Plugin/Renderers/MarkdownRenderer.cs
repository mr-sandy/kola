namespace Sample.Plugin.Renderers
{
    using Kola.Domain.Composition;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    public class MarkdownRenderer : IRenderer<AtomInstance>
    {
        private readonly IPluginComponentSpecification<IComponentWithProperties> specification;

        public MarkdownRenderer(IPluginComponentSpecification<IComponentWithProperties> specification)
        {
            this.specification = specification;
        }

        public IResult Render(AtomInstance atom)
        {
            var transformer = new MarkdownSharp.Markdown();

            var markdown = atom.Properties.Get("markdown");

            var html = transformer.Transform(markdown);

            return new Result(viewHelper => viewHelper.RenderPartial("Markdown", html));
        }
    }
}
