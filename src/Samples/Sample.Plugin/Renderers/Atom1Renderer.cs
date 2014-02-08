namespace Sample.Plugin.Renderers
{
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    public class Atom1Renderer : IRenderer<AtomInstance>
    {
        private readonly IAtom1Dependency atom1Dependency;

        public Atom1Renderer(IAtom1Dependency atom1Dependency)
        {
            this.atom1Dependency = atom1Dependency;
        }

        public IResult Render(AtomInstance atom)
        {
            return new Result(viewHelper => viewHelper.RenderPartial("atom-1", atom));
        }
    }
}
