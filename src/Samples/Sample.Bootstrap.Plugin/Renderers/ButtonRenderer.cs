namespace Sample.Bootstrap.Plugin.Renderers
{
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    public class ButtonRenderer : IRenderer<AtomInstance>
    {
        public IResult Render(AtomInstance atom)
        {
            return new Result(viewHelper => viewHelper.RenderPartial("Button", atom));
        }
    }
}
