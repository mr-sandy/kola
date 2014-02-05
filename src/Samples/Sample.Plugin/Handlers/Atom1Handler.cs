namespace Sample.Plugin.Handlers
{
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    public class Atom1Handler : IHandler<AtomInstance>
    {
        private readonly IAtom1Dependency atom1Dependency;

        public Atom1Handler(IAtom1Dependency atom1Dependency)
        {
            this.atom1Dependency = atom1Dependency;
        }

        public IResult Render(AtomInstance atom)
        {
            return new Result(viewHelper => viewHelper.RenderPartial("atom-1", atom));
        }
    }
}
