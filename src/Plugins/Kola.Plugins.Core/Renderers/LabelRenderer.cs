namespace Kola.Plugins.Core.Renderers
{
    
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    public class LabelRenderer : IRenderer<AtomInstance>
    {
        public IResult Render(AtomInstance atom)
        {
            return new Result(viewHelper => viewHelper.RenderPartial("Label", atom));
        }
    }
}
