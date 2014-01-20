namespace Sample.Plugin.Handlers
{
    using Kola.Domain;
    using Kola.Domain.Instances;
    using Kola.Rendering;

    public class Atom1Handler : IHandler
    {
        private readonly IAtom1Dependency atom1Dependency;

        public Atom1Handler(IAtom1Dependency atom1Dependency)
        {
            this.atom1Dependency = atom1Dependency;
        }

        public IResult HandleRequest(IComponentInstance component)
        {
            return new Result(viewHelper => viewHelper.RenderPartial("atom-1", component));
        }
    }
}
